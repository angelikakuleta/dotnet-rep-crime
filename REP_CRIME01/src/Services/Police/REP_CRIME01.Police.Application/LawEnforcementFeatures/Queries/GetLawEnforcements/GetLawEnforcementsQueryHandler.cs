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

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Queries
{

    public static partial class GetLawEnforcements
    {
        public record Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepository<LawEnforcement> _repository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<LawEnforcement> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                var qs = request.QueryString;
                Expression<Func<LawEnforcement, bool>> filterExpression = string.IsNullOrEmpty(qs.SearchPhrase) 
                    ? x => 1 == 1
                    : x => x.Code.ToLower().Contains(qs.SearchPhrase.ToLower()) || x.City.ToLower().Contains(qs.SearchPhrase.ToLower());

                Expression<Func<LawEnforcement, object>> sortBy = x => x.Code;

                bool sortDesc = string.IsNullOrEmpty(qs.OrderBy) || qs.OrderBy.ToLower().Contains("desc");
                int pageIndex = qs.PageIndex;
                int pageSize = qs.PageSize;

                var entities = await _repository.FindAllAsync(filterExpression, sortBy, sortDesc, pageIndex, pageSize);
                var count = await _repository.CountAsync(filterExpression);
                var items = _mapper.Map<List<LawEnforcementVM>>(entities);
                
                return new Response { Result = new PaginatedResult<LawEnforcementVM>(items, count, pageIndex, pageSize) };
            }
        }
    }
}
