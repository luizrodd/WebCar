using MediatR;
using WebCar.Domain.Models;
using WebCar.Domain.Repositories;

namespace WebCar.Application.Application.Commands.CreateVersion;


public class CreateVersionCommandHandler : IRequestHandler<CreateVersionCommand, bool>
{
    public Task<bool> Handle(CreateVersionCommand request, CancellationToken cancellationToken)
    {
        return Task.FromResult(true);
    }
}

public record CreateVersionCommand(Guid ModelId, string Name) : IRequest<bool>
{
}
