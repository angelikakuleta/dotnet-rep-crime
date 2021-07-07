﻿using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using System;

namespace REP_CRIME01.Police.Application.Commands
{
    public static partial class CreateLawEnforcement
    {
        public record Command : IRequest<Response>
        {
            public string Code { get; init; }
            public string Rank { get; init; }
            public string PoliceDepartmentCode { get; init; }
            public string City { get; init; }
        }

        public record Response : BaseResponse<Guid> { }
    }
}