using AutoMapper;
#if IncludePlayerInfrastructure
using SFC.GeneralTemplate.Messages.Events.GeneralTemplate.Data;
using SFC.GeneralTemplate.Application.Interfaces.GeneralTemplate.Data.Models;
#endif
using SFC.GeneralTemplate.Messages.Commands.Common;

namespace SFC.GeneralTemplate.Infrastructure.Extensions;
public static class MessagesExtensions
{
#if IncludePlayerInfrastructure
    public static DataInitialized BuildGeneralTemplateDataInitializedEvent(this IMapper mapper, GetAllGeneralTemplateDataModel model)
    {
        DataInitialized message = new()
        {
        };

        return message;
    }
#endif

    public static T SetCommandInitiator<T>(this T command, string initiator) where T : InitiatorCommand
    {
        command.Initiator = initiator;
        return command;
    }
}
