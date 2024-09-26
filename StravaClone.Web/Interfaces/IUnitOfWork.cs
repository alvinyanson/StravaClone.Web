﻿namespace StravaClone.Web.Interfaces
{
    public interface IUnitOfWork
    {
        IClubRepository Club { get; }

        IRaceRepository Race { get; }

        IUserRepository User { get; }

        IDashboardRepository Dashboard { get; }
    }
}
