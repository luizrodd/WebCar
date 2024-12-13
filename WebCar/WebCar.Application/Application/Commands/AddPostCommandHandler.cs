using MediatR;
using WebCar.Application.Application.Models.Requests;
using WebCar.Application.Application.Services;
using WebCar.Domain.Interfaces;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Api.Application.Commands
{
    public class AddPostCommandHandler(IExternalSourceRepository<Post, Guid> postRepository, IUserRepository userRepository, IFileManagerService fileManagerService) : IRequestHandler<AddPostCommand, bool>
    {
        private readonly IExternalSourceRepository<Post, Guid> _postRepository = postRepository ?? throw new ArgumentNullException(nameof(postRepository));
        private readonly IUserRepository _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
        private readonly IFileManagerService _fileManagerService = fileManagerService ?? throw new ArgumentNullException(nameof(fileManagerService));
        public async Task<bool> Handle(AddPostCommand request, CancellationToken cancellationToken)
        {
            var user = _userRepository.Get(request.Post.UserId);
            if (user == null)
                return false;

            var car = new Car(
                request.Post.Kilometer,
                request.Post.YearOfManufacture,
                request.Post.YearOfModel,
                request.Post.Armored,
                request.Post.Licensed,
                request.Post.Clutch,
                request.Post.Fuel,
                request.Post.Body,
                request.Post.Condition,
                request.Post.VersionId,
                request.Post.Optionals.Select(x => new CarOptional(x)).ToList()
                );

            var post = new Post(
                request.Post.UserId, 
                request.Post.Price, 
                request.Post.Localization, 
                request.Post.Description, 
                request.Post.AcceptTrade,
                car,
                request.Post.Images.Select(x => new ImageDraft(x.FileName, GetFileContent(x))).ToList(),
                _fileManagerService
                );

            _postRepository.Save();
            return true;
        }
        static byte[] GetFileContent(IFormFile file)
        {
            if (file == null)
                return null;

            using var stream = file.OpenReadStream();
            byte[] fileContent = new byte[stream.Length];
            stream.Read(fileContent, 0, (int)stream.Length);
            return fileContent;
        }
    }

    public record AddPostCommand(AddPostRequest Post) : IRequest<bool>{}
}
