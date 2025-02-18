using Application.CQRS.Users.ResponseDtos;
using Common.GlobalResponses.Generics;
using MediatR;
using Repository.Common;

namespace Application.CQRS.Users.Handlers;

public class GetByEmail
{
    public class Query : IRequest<Result<GetByEmailDto>>
    {
        public string Email { get; set; }
    }

    public class Handler(IUnitOfWork unitOfWork) : IRequestHandler<Query, Result<GetByEmailDto>>
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Result<GetByEmailDto>> Handle(Query request, CancellationToken cancellationToken)
        {
            var currentUser = await _unitOfWork.UserRepository.GetUserByEmailAsync(request.Email);
            if (currentUser == null)
            {
                return new Result<GetByEmailDto>()
                {
                    Errors = ["User can't found"],
                    IsSuccess = true
                };
            }

                GetByEmailDto user = new()
                {
                    Id = currentUser.Id,
                    Name = currentUser.Name,
                    Surname = currentUser.Surname,
                    Email = currentUser.Email,
                    Phone = currentUser.Phone
                };

                return new Result<GetByEmailDto>() { Data = user, Errors = [], IsSuccess = true };
            
        }
    }
}
