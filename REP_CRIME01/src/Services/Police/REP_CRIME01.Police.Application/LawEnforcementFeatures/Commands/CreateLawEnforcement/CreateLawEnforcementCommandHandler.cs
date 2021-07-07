 using AutoMapper;
using MediatR;
using REP_CRIME01.CQRSResponse.Responses;
using REP_CRIME01.Police.Domain.Contracts;
using REP_CRIME01.Police.Domain.Entities;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace REP_CRIME01.Police.Application.LawEnforcementFeatures.Commands
{
    public static partial class CreateLawEnforcement
    {
        public class Handler : IRequestHandler<Command, Response>
        {
            private readonly IRepository<LawEnforcement> _repository;
            private readonly IMapper _mapper;

            public Handler(IMapper mapper, IRepository<LawEnforcement> repository)
            {
                _mapper = mapper;
                _repository = repository;
            }

            public async Task<Response> Handle(Command request, CancellationToken cancellationToken)
            {
                var isCodeUnique = (await _repository.FindAsync(x => x.Code == request.Code)) is null;
                if (!isCodeUnique)
                    return new Response { Status = ResponseStatus.BadQuery, ErrorMessage = "The object with given code already exists." };

                var entity = _mapper.Map<LawEnforcement>(request);
                await _repository.AddAsync(entity);
                return new Response { Result = entity.Id };
            }
        }
    }
}
