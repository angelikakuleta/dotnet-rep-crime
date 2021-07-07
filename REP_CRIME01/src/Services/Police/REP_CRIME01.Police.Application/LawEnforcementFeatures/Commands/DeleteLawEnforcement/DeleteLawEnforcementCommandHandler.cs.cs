using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class DeleteLawEnforcement
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<LawEnforcement> _repository;

            public Handler(IRepository<LawEnforcement> repository)
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
