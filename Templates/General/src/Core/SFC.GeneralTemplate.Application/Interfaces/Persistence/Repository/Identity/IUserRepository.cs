﻿using SFC.GeneralTemplate.Application.Interfaces.Persistence.Context;
using SFC.GeneralTemplate.Domain.Entities.Identity;

namespace SFC.GeneralTemplate.Application.Interfaces.Persistence.Repository.Identity;

/// <summary>
/// Repository for users from Identity service.
/// </summary>
public interface IUserRepository : IRepository<User, IIdentityDbContext, Guid>
{
    /// <summary>
    /// Try add users to database.
    /// Skip already existing users, without throwing error.
    /// </summary>
    /// <param name="users">Users from Identity service.</param>
    /// <returns>Users from Identity service.</returns>
    Task<User[]> AddRangeIfNotExistsAsync(params User[] users);
}
