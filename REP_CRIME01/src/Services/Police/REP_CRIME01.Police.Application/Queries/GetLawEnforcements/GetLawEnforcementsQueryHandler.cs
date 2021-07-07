using AutoMapper;
using MediatR;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.Queries
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
                Expression<Func<LawEnforcement, bool>> filterExpression = string.IsNullOrEmpty(request.SearchPhrase) 
                    ? x => 1 == 1
                    : x => x.Code.ToLower().Contains(request.SearchPhrase.ToLower()) || x.City.ToLower().Contains(request.SearchPhrase.ToLower());

                Expression<Func<LawEnforcement, object>> sortBy = x => x.Code;

                bool sortDesc = string.IsNullOrEmpty(request.OrderBy) || request.OrderBy.ToLower().Contains("desc");
                int pageIndex = request.PageIndex;
                int pageSize = request.PageSize;

                var entities = await _repository.FindAllAsync(filterExpression, sortBy, sortDesc, request.PageIndex, pageSize);
                var count = await _repository.CountAsync(filterExpression);
                var items = _mapper.Map<List<LawEnforcementVM>>(entities);
                
                return new Response { Result = new PaginatedResult<LawEnforcementVM>(items, count, pageIndex, pageSize) };
            }
        }
    }
}
