using MediatR;

namespace WebCar.Application.Application.Commands.SoldPost
{
    public class SoldPostCommandHandler : IRequestHandler<SoldPostCommand, bool>
    {
        public Task<bool> Handle(SoldPostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public record SoldPostCommand(Guid Id) : IRequest<bool>;
}
