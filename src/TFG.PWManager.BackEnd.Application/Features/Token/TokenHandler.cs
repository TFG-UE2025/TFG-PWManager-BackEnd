using MediatR;
using TFG.PWManager.BackEnd.Application.Features.Token.Commans;
using TFG.PWManager.BackEnd.Application.Features.Token.Queries;
using TFG.PWManager.BackEnd.Domain.Commons;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.Application.Features.Token
{
    public class TokenHandler :
        IRequestHandler<GetTokenByEmailQuery, TokenModel>,
        IRequestHandler<GetEnabledTokenQuery, bool>,
        IRequestHandler<GetTokenRefreshByEmailQuery, TokenModel>,
        IRequestHandler<GetTokenConfig, TokenConfigModel>,
        IRequestHandler<AddTokenCommand, OkResponseModel>,
        IRequestHandler<AddRefreshTokenCommand, OkResponseModel>,
        IRequestHandler<PutTokenCommand, OkResponseModel>,
        IRequestHandler<PutRefreshTokenCommand, OkResponseModel>
    {
        public Task<TokenModel> Handle(GetTokenByEmailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Handle(GetEnabledTokenQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TokenModel> Handle(GetTokenRefreshByEmailQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<TokenConfigModel> Handle(GetTokenConfig request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(AddRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(PutTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<OkResponseModel> Handle(PutRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
