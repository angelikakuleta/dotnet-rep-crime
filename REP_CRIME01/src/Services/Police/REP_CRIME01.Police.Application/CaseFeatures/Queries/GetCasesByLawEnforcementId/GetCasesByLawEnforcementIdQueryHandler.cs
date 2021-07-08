using AutoMapper;
using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Common.Models;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.CaseFeatures.Queries
{

    public static partial class GetCasesByLawEnforcementId
    {
        public record Handler : IRequestHandler<Query, Response>
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

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var qs = request.QueryString;
                var result = await _lawEnforcementRepository.FindByIdAsync(request.LawEnforcementId);
                if (result is null)
                {
                    return new Response { Status = ResponseStatus.NotFound };
                }

                Expression<Func<Case, bool>> filterExpression = string.IsNullOrEmpty(qs.SearchPhrase) 
                    ? x => x.LawEnforcement.Id == request.LawEnforcementId
                    : x => x.LawEnforcement.Id == request.LawEnforcementId && x.Description.ToLower().Contains(qs.SearchPhrase.ToLower());

                Expression<Func<Case, object>> sortBy = Enum.Parse(typeof(CasesOrder), qs.OrderBy, true) switch
                {
                    CasesOrder.CRIMEDATE or CasesOrder.CRIMEDATE_DESC => x => x.CrimeDate,
                    CasesOrder.DATEREPORTED or CasesOrder.DATEREPORTED_DESC => x => x.DateReported,
                    _ => x => x.CrimeDate
                }; 

                bool sortDesc = string.IsNullOrEmpty(qs.OrderBy) || qs.OrderBy.ToLower().Contains("desc");
                int pageIndex = qs.PageIndex;
                int pageSize = qs.PageSize;

                var entities = await _caseRepository.FindAllAsync(filterExpression, sortBy, sortDesc, pageIndex, pageSize);
                var count = await _caseRepository.CountAsync(filterExpression);
                var items = _mapper.Map<List<CaseVM>>(entities);
                
                return new Response { Result = new PaginatedResult<CaseVM>(items, count, pageIndex, pageSize) };
            }
        }
    }
}
