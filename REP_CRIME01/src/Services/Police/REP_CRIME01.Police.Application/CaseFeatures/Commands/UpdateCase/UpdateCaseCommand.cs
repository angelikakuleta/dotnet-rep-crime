using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.DTOs;
using System;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class UpdateCase
    {
        public record Command : IRequest<Response>
        {
            public UpdateCaseDto UpdateCaseDto { get; set; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}
