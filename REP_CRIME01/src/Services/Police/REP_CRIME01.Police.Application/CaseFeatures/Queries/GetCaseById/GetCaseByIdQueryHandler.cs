using AutoMapper;
using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Application.Models;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.CaseFeatures.Queries
{
    public static partial class GetCaseById
    {
        public class Handler : IRequestHandler<Query, Response>
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
                var result = await _repository.FindByIdAsync(request.Id);
                if (result is null)
                {
                    return new Response { Status = ResponseStatus.NotFound };
                }                   

                var vm = _mapper.Map<CaseVM>(result);
                return new Response { Result = vm };
            }
        }
    }
}
