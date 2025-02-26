using System.Reflection;

using Google.Protobuf.WellKnownTypes;

using SFC.GeneralTemplate.Application.Common.Mappings.Base;
using SFC.GeneralTemplate.Application.Features.Data.Commands.Reset;
using SFC.GeneralTemplate.Application.Common.Extensions;
using SFC.GeneralTemplate.Application.Features.Identity.Commands.Create;
using SFC.GeneralTemplate.Application.Features.Identity.Commands.CreateRange;
using SFC.GeneralTemplate.Application.Common.Dto.Identity;

namespace SFC.GeneralTemplate.Infrastructure.Mapping;
public class MappingProfile : BaseMappingProfile
{
    protected override Assembly Assembly => Assembly.GetExecutingAssembly();

    public MappingProfile() : base()
    {
        ApplyCustomMappings();
    }

    private void ApplyCustomMappings()
    {
        #region Simple types       

        CreateMap<Timestamp, DateTime>()
           .ConvertUsing(value => value.ToDateTime());

        CreateMap<Duration, TimeSpan>()
            .ConvertUsing(value => value.ToTimeSpan());

        #endregion Simple types

        #region Data

        // messages        
        CreateMapDataMessages();

        #endregion Data

        #region Identity

        // messages        
        CreateMapIdentityMessages();

        // contracts        
        CreateMapIdentityContracts();

        #endregion Identity
    }

    #region Data

    private void CreateMapDataMessages()
    {
        CreateMap<SFC.Data.Messages.Events.DataInitialized, ResetDataCommand>().IgnoreAllNonExisting();
    }

    #endregion Data

    #region Identity

    private void CreateMapIdentityMessages()
    {
        CreateMap<SFC.Identity.Messages.Events.UserCreated, CreateUserCommand>().IgnoreAllNonExisting();

        CreateMap<IEnumerable<SFC.Identity.Messages.Models.User>, CreateUsersCommand>()
            .ForMember(p => p.Users, d => d.MapFrom(z => z));

        CreateMap<SFC.Identity.Messages.Models.User, UserDto>();
    }

    private void CreateMapIdentityContracts()
    {
        CreateMap<Guid, SFC.Identity.Contracts.Messages.Get.GetUserRequest>()
            .ConvertUsing(id => new SFC.Identity.Contracts.Messages.Get.GetUserRequest { Id = id.ToString() });
        CreateMap<SFC.Identity.Contracts.Models.Get.User, UserDto>();
    }

    #endregion Identity
}
