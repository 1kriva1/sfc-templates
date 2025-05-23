using AutoMapper;

using MassTransit;

using SFC.GeneralTemplate.Application.Interfaces.Common;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.General;
using SFC.GeneralTemplate.Application.Interfaces.Metadata;
using SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.GeneralTemplate.General;
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.General;

namespace SFC.GeneralTemplate.Infrastructure.Services.GeneralTemplate.General;
public class GeneralTemplateSeedService(
    IMapper mapper,
    IPublishEndpoint publisher,
    IDateTimeService dateTimeService,
    IMetadataService metadataService,
    IGeneralTemplateRepository generalTemplateRepository) : IGeneralTemplateSeedService
{
    private readonly IMapper _mapper = mapper;
    private readonly IPublishEndpoint _publisher = publisher;
    private readonly IDateTimeService _dateTimeService = dateTimeService;
    private readonly IMetadataService _metadataService = metadataService;
    private readonly IGeneralTemplateRepository _generalTemplateRepository = generalTemplateRepository;

    #region Stub data

    private static readonly List<long> IDS = [];

    #endregion Stub data

    #region Public

    public async Task<IEnumerable<GeneralTemplateEntity>> GetSeedGeneralTemplateMultipleAsync()
    {
        //return await _generalTemplateRepository.GetByIdsAsync().ConfigureAwait(true);
        return await Task.FromResult<IEnumerable<GeneralTemplateEntity>>([]).ConfigureAwait(true);
    }

    public async Task SeedGeneralTemplateMultipleAsync(CancellationToken cancellationToken = default)
    {
        IEnumerable<GeneralTemplateEntity> generalTemplateMultiple = await CreateSeedGeneralTemplateMultipleAsync().ConfigureAwait(true);

        GeneralTemplateEntity[] seedGeneralTemplateMultiple = await
            _generalTemplateRepository.AddRangeIfNotExistsAsync([.. generalTemplateMultiple]).ConfigureAwait(true);

        await PublishGeneralTemplateMultipleSeededEventAsync(seedGeneralTemplateMultiple, cancellationToken).ConfigureAwait(true);

        await _metadataService.CompleteAsync(MetadataServiceEnum.GeneralTemplate, MetadataDomainEnum.GeneralTemplate, MetadataTypeEnum.Seed).ConfigureAwait(true);
    }

    #endregion Public

    #region Private

    private async Task<IEnumerable<GeneralTemplateEntity>> CreateSeedGeneralTemplateMultipleAsync()
    {
        List<GeneralTemplateEntity> result = [];

        foreach (long item in IDS)
        {
            IEnumerable<GeneralTemplateEntity> part = await BuildGeneralTemplateAsync(item).ConfigureAwait(true);
            result.AddRange(part);
        }

        return result;
    }

    private async Task<IEnumerable<GeneralTemplateEntity>> BuildGeneralTemplateAsync(long id)
    {
        DateTime createdDate = _dateTimeService.Now;

        // TODO
        Guid userId = Guid.NewGuid();

        GeneralTemplateEntity generalTemplate = new()
        {
            CreatedBy = userId,
            CreatedDate = createdDate,
            LastModifiedBy = userId,
            LastModifiedDate = createdDate,
        };

        return await Task.FromResult(new List<GeneralTemplateEntity> { generalTemplate }).ConfigureAwait(true);
    }

    private Task PublishGeneralTemplateMultipleSeededEventAsync(IEnumerable<GeneralTemplateEntity> generalTemplateMultiple, CancellationToken cancellationToken = default)
    {
        GeneralTemplateMultipleSeeded @event = _mapper.Map<GeneralTemplateMultipleSeeded>(generalTemplateMultiple);
        return _publisher.Publish(@event, cancellationToken);
    }

    #endregion Private
}
