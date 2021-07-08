using AutoMapper;
using MediatR;
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

    public static partial class GetCases
    {
        public record Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepository<Case> _repository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<Case> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var qs = request.QueryString;
                Expression<Func<Case, bool>> filterExpression = string.IsNullOrEmpty(qs.SearchPhrase) 
                    ? x => 1 == 1
                    : x => x.Description.ToLower().Contains(qs.SearchPhrase.ToLower());

                Expression<Func<Case, object>> sortBy = Enum.Parse(typeof(CasesOrder), qs.OrderBy, true) switch
                {
                    CasesOrder.CRIMEDATE or CasesOrder.CRIMEDATE_DESC => x => x.CrimeDate,
                    CasesOrder.DATEREPORTED or CasesOrder.DATEREPORTED_DESC => x => x.DateReported,
                    _ => x => x.CrimeDate
                }; 

                bool sortDesc = string.IsNullOrEmpty(qs.OrderBy) || qs.OrderBy.ToLower().Contains("desc");
                int pageIndex = qs.PageIndex;
                int pageSize = qs.PageSize;

                var entities = await _repository.FindAllAsync(filterExpression, sortBy, sortDesc, pageIndex, pageSize);
                var count = await _repository.CountAsync(filterExpression);
                var items = _mapper.Map<List<CaseVM>>(entities);
                
                return new Response { Result = new PaginatedResult<CaseVM>(items, count, pageIndex, pageSize) };
            }
        }
    }
}
