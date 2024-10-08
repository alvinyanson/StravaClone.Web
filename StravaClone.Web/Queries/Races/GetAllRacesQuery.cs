﻿using MediatR;
using StravaClone.Entities.Models;

namespace StravaClone.Web.Queries.Races
{
    public record GetAllRacesQuery : IRequest<IEnumerable<Race>>
    {
    }
}
