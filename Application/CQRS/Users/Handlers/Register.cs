using Application.CQRS.Users.ResponseDtos;
using Common.GlobalResponses;
using Common.GlobalResponses.Generics;
using MediatR;

namespace Application.CQRS.Users.Handlers;

public class Register
{
    public class Command : IRequest<Result<RegisterDto>>
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
    }

    public class Handler : IRequestHandler<Command, Result<RegisterDto>>
    {
        public Task<Result<RegisterDto>> Handle(Command request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
