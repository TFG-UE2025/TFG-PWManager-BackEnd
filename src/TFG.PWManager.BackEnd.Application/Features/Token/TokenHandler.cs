using AutoMapper;
using MediatR;
using System.Globalization;
using TFG.PWManager.BackEnd.Application.Features.Token.Commans;
using TFG.PWManager.BackEnd.Application.Features.Token.Queries;
using TFG.PWManager.BackEnd.Application.Registration;
using TFG.PWManager.BackEnd.Domain.Commons;
using TFG.PWManager.BackEnd.Domain.Contracts.Persistence;
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
        private readonly ITokenRepository _tokenRepository;
        private readonly IMapper _mapper;

        public TokenHandler(ITokenRepository tokenRepository, IMapper mapper)
        {
            _tokenRepository = tokenRepository;
            _mapper = mapper;
        }

        public async Task<TokenModel> Handle(GetTokenByEmailQuery request, CancellationToken cancellationToken)
        {
            var token = await _tokenRepository.GetTokenByEmailAsync(new List<string> { request.Email });

            return _mapper.Map<TokenModel>(token.FirstOrDefault());
        }

        public async Task<bool> Handle(GetEnabledTokenQuery request, CancellationToken cancellationToken)
        {
            var enabled = false;
            var tokens = await _tokenRepository.GetTokenByEmailAsync(new List<string> { request.Email });
            if (tokens.Any())
            {
                var token = tokens.First();
                enabled = token.Enabled;
            }

            return enabled;
        }

        public async Task<TokenModel> Handle(GetTokenRefreshByEmailQuery request, CancellationToken cancellationToken)
        {
            var refreshToken = await _tokenRepository.GetRefeshTokenByEmailAsync(request.Email);

            return _mapper.Map<TokenModel>(refreshToken);
        }

        public async Task<TokenConfigModel> Handle(GetTokenConfig request, CancellationToken cancellationToken)
        {
            var tokenConfig = await _tokenRepository.GetTokenConfigAsync();

            return _mapper.Map<TokenConfigModel>(tokenConfig);
        }

        public async Task<OkResponseModel> Handle(AddTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _mapper.Map<Domain.Entities.Token>(request.TokenModel);
            token.Enabled = true;

            return await _tokenRepository.AddTokenAsync(token);
        }

        public async Task<OkResponseModel> Handle(AddRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var token = _mapper.Map<Domain.Entities.Token>(request.TokenModel);

            token!.AccessToken = request.TokenModel.RefreshToken;
            token.IsRefreshToken = true;
            token.Enabled = true;

            return await _tokenRepository.AddTokenAsync(token);
        }

        public async Task<OkResponseModel> Handle(PutTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new OkResponseModel
            {
                Id = 0,
                Message = "No había datos para actualizar"
            };

            var tokens = await _tokenRepository.GetTokenByEmailAsync(request.ListEmail);
            foreach (var token in tokens)
            {
                token.Enabled = false;

                response = await _tokenRepository.UpdateTokenAsync(token);
            }

            return response;
        }

        public async Task<OkResponseModel> Handle(PutRefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var response = new OkResponseModel
            {
                Id = 0,
                Message = "No había datos para actualizar"
            };

            var token = await _tokenRepository.GetRefeshTokenByEmailAsync(request.Email);
            if (token != null)
            {
                token.ExpiredDate = DateTime.ParseExact(request.ExpiredDate, ConfigurationManager.LongDateFormat, CultureInfo.InvariantCulture);

                response = await _tokenRepository.UpdateTokenAsync(token);
            }

            return response;
        }
    }
}
