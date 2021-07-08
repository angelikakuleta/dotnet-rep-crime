using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;
using System;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Queries
{
    public static partial class GetLawEnforcementById
    {
        public record Query : IRequest<Response>
        {
            public Guid Id { get; init; }
        }

        public record Response : BaseResponse<LawEnforcementVM> { }
    }
}
