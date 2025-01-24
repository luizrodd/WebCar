using MediatR;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Application.Application.Commands.CreateModel;

public class CreateModelCommandHandler(IBrandRepository brandRepository) : IRequestHandler<CreateModelCommand, bool>
{
    private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    public Task<bool> Handle(CreateModelCommand request, CancellationToken cancellationToken)
    {
        var brand = _brandRepository.Get(request.BrandId);

        brand.AddModel(new Model(request.Name));

        _brandRepository.SaveChanges();

        return Task.FromResult(true);
    }
}

public record CreateModelCommand(Guid BrandId, string Name) : IRequest<bool>
{
}
