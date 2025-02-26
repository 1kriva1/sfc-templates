using SFC.GeneralTemplate.Application.Common.Dto.Identity;
using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Application.Interfaces.Reference;

/// <summary>
/// Identity user reference service.
/// </summary>
public interface IIdentityReference : IReference<User, Guid, UserDto> { }
