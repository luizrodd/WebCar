using MediatR;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Application.Application.Commands.CreateVersion;


public class CreateVersionCommandHandler(IBrandRepository brandRepository) : IRequestHandler<CreateVersionCommand, bool>
{
    private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    public Task<bool> Handle(CreateVersionCommand request, CancellationToken cancellationToken)
    {
        var brand = _brandRepository.GetAll().Where(x => x.Models.Any(m => m.Id == request.ModelId)).FirstOrDefault();

        var model = brand.Models.FirstOrDefault(x => x.Id == request.ModelId);

        model.AddVersion(new Domain.Models.Version(request.Name));

        _brandRepository.SaveChanges();

        return Task.FromResult(true);
    }
}

public record CreateVersionCommand(Guid ModelId, string Name) : IRequest<bool>
{
}
