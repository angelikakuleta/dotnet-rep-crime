using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Common.Models;
using System;

namespace REP_CRIME01.Crime.Application.EventFeatures.Queries
{
    public static partial class GetCrimeEventById
    {
        public record Query : IRequest<Response>
        {
            public Guid Id { get; init; }
        }

        public record Response : BaseResponse<CrimeEventVM> { }
    }
}
