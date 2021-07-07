using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class DeleteCrimeEvent
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<CrimeEvent> _repository;

            public Handler(IRepository<CrimeEvent> repository)
            {
                _repository = repository;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var isSuccessful = await _repository.DeleteByIdAsync(request.EventId);
                return isSuccessful 
                    ? new Response { Status = ResponseStatus.Success }
                    : new Response { Status = ResponseStatus.NotFound };
            }
        }
    }
}
