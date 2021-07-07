using AutoMapper;
using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Crime.Domain.Contracts;
using REP_CRIME01.Crime.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Crime.Application.EventFeatures.Commands
{
    public static partial class UpdateCrimeEvent
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<CrimeEvent> _repository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<CrimeEvent> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var entity = await _repository.FindByIdAsync(request.Id);
                if (entity is null)
                {
                    return new Response { Status = ResponseStatus.NotFound };
                }

                _mapper.Map(request, entity);
                await _repository.UpdateAsync(entity);

                return new Response { Status = ResponseStatus.Success };
            }
        }
    }
}
