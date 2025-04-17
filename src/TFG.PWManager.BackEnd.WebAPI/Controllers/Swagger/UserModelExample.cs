using Swashbuckle.AspNetCore.Filters;
using System.Diagnostics.CodeAnalysis;
using TFG.PWManager.BackEnd.Domain.Models;

namespace TFG.PWManager.BackEnd.WebAPI.Controllers.Swagger
{
    [ExcludeFromCodeCoverage]
    public class UserModelExample : IExamplesProvider<UserModel>
    {
        public UserModel GetExamples()
        {
            return new UserModel
            {
                Id = 1,
                DisplayName = "Display Name",
                Name = "User Name",
                Surname = "User Surname",
                PhoneNumber = "User Phone Number",
                Email = "user@mail.com",
                PasswordHash = "xxxXXXXXXXX==",
                ActiveChk = true,
                LanguageId = 1,
                LanguageCode = "SP",
                PasswordExpiredDate= DateTime.Now,
            };
        }
    }

    [ExcludeFromCodeCoverage]
    public class UserModelListExample : IExamplesProvider<IEnumerable<UserModel>>
    {
        public IEnumerable<UserModel> GetExamples()
        {
            return new List<UserModel> {
                new UserModelExample().GetExamples()
            };
        }
    }

    [ExcludeFromCodeCoverage]
    public class UserPaginationModelExample : IExamplesProvider<DataPaginationModel<UserModel>>
    {
        public DataPaginationModel<UserModel> GetExamples()
        {
            return new DataPaginationModel<UserModel>()
            {
                PageNumber = 1,
                PageSize = 10,
                TotalSize = 100,
                Data = new UserModelListExample().GetExamples()
            };
        }
    }
}
