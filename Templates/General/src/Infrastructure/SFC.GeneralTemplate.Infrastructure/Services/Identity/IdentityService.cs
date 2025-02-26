using AutoMapper;

using Microsoft.Extensions.Configuration;

using SFC.GeneralTemplate.Application.Common.Dto.Identity;
using SFC.GeneralTemplate.Application.Interfaces.Identity;
using SFC.GeneralTemplate.Infrastructure.Extensions.Grpc;
using SFC.Identity.Contracts.Messages.Get;

using static SFC.Identity.Contracts.Services.IdentityService;

namespace SFC.GeneralTemplate.Infrastructure.Services.Identity;
public class IdentityService(
    IdentityServiceClient client,
    IMapper mapper,
    IConfiguration configuration) : IIdentityService
{
    private readonly IdentityServiceClient _client = client;
    private readonly IMapper _mapper = mapper;
    private readonly IConfiguration _configuration = configuration;

    public async Task<UserDto?> GetUserAsync(Guid id, CancellationToken cancellationToken = default)
    {
        GetUserRequest request = _mapper.Map<GetUserRequest>(id);

        return await GrpcClientExtensions.CallWithAuditableAsync<GetUserRequest, GetUserResponse, UserDto>(
            _client.GetUserAsync,
            request,
            _configuration,
            (response) => _mapper.Map<UserDto>(response.User),
            null,
            cancellationToken).ConfigureAwait(true);
    }
}