﻿ using AutoMapper;
using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class CreateCase
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<LawEnforcement> _lawEnforcementRepository;
            private readonly IRepository<Case> _caseRepository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<LawEnforcement> lawEnforcementRepository, IRepository<Case> caseRepository)
            {
                _mapper = mapper;
                _lawEnforcementRepository = lawEnforcementRepository;
                _caseRepository = caseRepository;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var lawEnforcementEntity = await _lawEnforcementRepository.FindAsync(x => x.Code == request.LawEnforcementCode);
                if (lawEnforcementEntity is null)
                    return new Response { Status = ResponseStatus.BadQuery, ErrorMessage = "The object with given code doesn't exists." };

                var entity = _mapper.Map<Case>(request);
                entity.LawEnforcement = lawEnforcementEntity;
                await _caseRepository.AddAsync(entity);
                return new Response { Result = entity.Id };
            }
        }
    }
}
