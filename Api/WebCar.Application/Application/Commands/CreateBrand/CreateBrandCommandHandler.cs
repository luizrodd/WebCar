using MediatR;
using Microsoft.IdentityModel.Tokens;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;
using WebCar.Infrastructure.Repositories;

namespace WebCar.Application.Application.Commands.CreateBrand;

public class CreateBrandCommandHandler(IBrandRepository brandRepository) : IRequestHandler<CreateBrandCommand, bool>
{
    private readonly IBrandRepository _brandRepository = brandRepository ?? throw new ArgumentNullException(nameof(brandRepository));
    public Task<bool> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
    {
        if(request.Name.IsNullOrEmpty())
            return Task.FromResult(false);

        _brandRepository.Add(new Brand(request.Name));

        _brandRepository.SaveChanges();

        return Task.FromResult(true);
    }
}

public record CreateBrandCommand(string Name) : IRequest<bool>
{
}
