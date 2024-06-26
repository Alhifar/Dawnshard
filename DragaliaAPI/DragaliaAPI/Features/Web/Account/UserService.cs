﻿using DragaliaAPI.Database;
using DragaliaAPI.Models.Generated;
using DragaliaAPI.Services;
using DragaliaAPI.Shared.PlayerDetails;
using Microsoft.EntityFrameworkCore;

namespace DragaliaAPI.Features.Web.Account;

public class UserService(
    IPlayerIdentityService playerIdentityService,
    ILoadService loadService,
    ApiContext apiContext
)
{
    public Task<User> GetUser(CancellationToken cancellationToken) =>
        apiContext
            .Players.Where(x => x.ViewerId == playerIdentityService.ViewerId)
            .Select(x => new User() { Name = x.UserData!.Name, ViewerId = x.ViewerId, })
            .FirstAsync(cancellationToken);

    public Task<UserProfile> GetUserProfile(CancellationToken cancellationToken) =>
        apiContext
            .PlayerUserData.Select(x => new UserProfile()
            {
                LastSaveImportTime = x.LastSaveImportTime,
                LastLoginTime = x.LastLoginTime
            })
            .FirstAsync(cancellationToken);

    public Task<LoadIndexResponse> GetSavefile(CancellationToken cancellationToken) =>
        loadService.BuildIndexData(cancellationToken);
}
