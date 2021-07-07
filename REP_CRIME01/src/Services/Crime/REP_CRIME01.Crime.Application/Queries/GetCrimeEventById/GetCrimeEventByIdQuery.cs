using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Application.Models;
using System;

namespace REP_CRIME01.Crime.Application.Queries
{
    public static partial class GetCrimeEventById
    {
        public record Query : IRequest<Response>
        {
            public Guid EventId { get; set; }
        }

        public record Response : BaseResponse<CrimeEventVM> { }
    }
}
