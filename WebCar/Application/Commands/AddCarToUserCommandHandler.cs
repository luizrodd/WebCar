using MediatR;
using WebCar.Api.Application.DTOs;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Api.Application.Commands
{
    public class AddCarToUserCommandHandler : IRequestHandler<AddCarToUserCommand, bool>
    {
        private readonly IUserRepository _userRepository;
        public AddCarToUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public Task<bool> Handle(AddCarToUserCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get(request.UserId);
            if (user == null)
                return Task.FromResult(false);

            user.AddPost(new Post
                (
                    request.PostDTO.Kilometer, request.PostDTO.YearOfManufacture, 
                    request.PostDTO.YearOfModel, request.PostDTO.Price,
                    request.PostDTO.Localization, request.PostDTO.Description, 
                    request.PostDTO.IsArmored, request.PostDTO.IPVA, 
                    request.PostDTO.AcceptTrade, request.PostDTO.IsLicensed, 
                    request.PostDTO.IsUsed, request.PostDTO.TransmissionType,
                    request.PostDTO.FuelType, request.PostDTO.BodyType, 
                    request.PostDTO.Version.Id, 
                    request.PostDTO.Images.Select(_ => new Image(_.Data, _.FileName, _.Description)).ToList(), 
                    request.PostDTO.PostOptionals.Select(_ => new PostOptional(_.OptionalTypeId)).ToList()
                ));

            return Task.FromResult(true);
        }
    }
    public class AddCarToUserCommand : IRequest<bool>
    {
        public Guid UserId { get; set; }
        public PostDTO PostDTO { get; set; }
    }
}
