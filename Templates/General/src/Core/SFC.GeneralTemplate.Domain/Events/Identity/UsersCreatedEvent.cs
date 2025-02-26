using SFC.GeneralTemplate.Domain.Common;
using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Domain.Events.Identity;
public class UsersCreatedEvent(IEnumerable<User> users) : BaseEvent
{
    public IEnumerable<User> Users { get; } = users;
}
