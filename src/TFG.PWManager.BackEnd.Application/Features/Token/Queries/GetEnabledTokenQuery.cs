using MediatR;

namespace TFG.PWManager.BackEnd.Application.Features.Token.Queries
{
    public class GetEnabledTokenQuery : IRequest<bool>
    {
        public string Email { get; set; }

        public GetEnabledTokenQuery(string email)
        {
            Email = email;
        }
    }
}
