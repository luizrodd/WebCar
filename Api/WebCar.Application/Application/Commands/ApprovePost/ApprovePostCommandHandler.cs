using MediatR;

namespace WebCar.Application.Application.Commands.ApprovePost
{
    public class ApprovePostCommandHandler : IRequestHandler<ApprovePostCommand, bool>
    {
        public Task<bool> Handle(ApprovePostCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
    public record ApprovePostCommand(Guid Id) : IRequest<bool>;
}
