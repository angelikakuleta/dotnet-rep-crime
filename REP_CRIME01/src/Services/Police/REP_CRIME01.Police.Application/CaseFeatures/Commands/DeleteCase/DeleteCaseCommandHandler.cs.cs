using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.CaseFeatures.Commands
{
    public static partial class DeleteCase
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<Case> _repository;

            public Handler(IRepository<Case> repository)
            {
                _repository = repository;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var isSuccessful = await _repository.DeleteByIdAsync(request.Id);
                return isSuccessful 
                    ? new Response { Status = ResponseStatus.Success }
                    : new Response { Status = ResponseStatus.NotFound };
            }
        }
    }
}
