using MediatR;

namespace PublishVsSendInMediatR.Commands
{
    public class CreateUserCommand : IRequest<int>
    {
        public string UserName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
    }
}
