using MediatR;

namespace WebCar.Application.Application.Commands.CancelPost
{
    public class CanceledPostCommandHandler : IRequestHandler<CanceledPostCommand, bool>
    {
        public Task<bool> Handle(CanceledPostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

    public record CanceledPostCommand(Guid Id) : IRequest<bool>;
}
