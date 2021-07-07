using AutoMapper;
using MediatR;
using REP_CRIME01.Crime.Application.Models;
using REP_CRIME01.Crime.Application.Responses;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Application.Queries
{

    public static partial class GetCrimeEvents
    {
        public record Handler : IRequestHandler<Query, Response>
        {
            private readonly IRepository<CrimeEvent> _repository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<CrimeEvent> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<Response> Handle(Query request, CancellationToken cancellationToken)
            {
                Expression<Func<CrimeEvent, bool>> filterExpression = string.IsNullOrEmpty(request.SearchPhrase) 
                    ? x => 1 == 1
                    : x => x.EventType.ToLower().Contains(request.SearchPhrase.ToLower()) || x.Description.ToLower().Contains(request.SearchPhrase.ToLower());

                Expression<Func<CrimeEvent, object>> sortBy = x => x.EventDate;

                bool sortDesc = string.IsNullOrEmpty(request.OrderBy) || request.OrderBy.ToLower().Contains("desc");
                int pageIndex = request.PageIndex;
                int pageSize = request.PageSize;

                var entities = await _repository.FindAllAsync(filterExpression, sortBy, sortDesc, request.PageIndex, pageSize);
                var count = await _repository.CountAsync(filterExpression);
                var items = _mapper.Map<List<CrimeEventVM>>(entities);
                
                return new Response { Result = new PaginatedResult<CrimeEventVM>(items, count, pageIndex, pageSize) };
            }
        }
    }
}
