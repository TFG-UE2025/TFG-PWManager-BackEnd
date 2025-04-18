using AutoMapper;
using TFG.PWManager.BackEnd.Application.Registration;
using TFG.PWManager.BackEnd.Domain.Commons;
using TFG.PWManager.BackEnd.Domain.Custom;
using TFG.PWManager.BackEnd.Domain.Entities;
using TFG.PWManager.BackEnd.Domain.Enums;
using TFG.PWManager.BackEnd.Domain.Extensions;

namespace TFG.PWManager.BackEnd.Application.Mappings.Resolvers
{
    public class DateTimeResolver :
        IMemberValueResolver<BaseModel, BaseEntity, string, DateTime>,
        IMemberValueResolver<BaseModel, BaseEntity, string?, DateTime?>,
        IMemberValueResolver<BaseEntity, BaseModel, DateTime, string?>,
        IMemberValueResolver<BaseEntity, BaseModel, DateTime?, string?>
    {
        protected readonly CurrentUserProvider _currentUserProvider;
        protected readonly string _tz = DateTimeEnum.Utc;

        public DateTimeResolver(CurrentUserProvider currentUserProvider)
        {
            _currentUserProvider = currentUserProvider;

            var currentUser = _currentUserProvider.GetCurrentUser();
            _tz = currentUser != null ? currentUser.TimeZoneId : _tz;
        }

        public virtual DateTime Resolve(BaseModel source, BaseEntity destination, string sourceMember, DateTime destMember, ResolutionContext context)
        {
            return sourceMember.StringToDate(ConfigurationManager.LongDateFormat, _tz);
        }

        public virtual DateTime? Resolve(BaseModel source, BaseEntity destination, string? sourceMember, DateTime? destMember, ResolutionContext context)
        {
            if (!string.IsNullOrEmpty(sourceMember))
            {
                return sourceMember.StringToDate(ConfigurationManager.LongDateFormat, _tz);
            }
            else
            {
                return null;
            }
        }

        public virtual string? Resolve(BaseEntity source, BaseModel destination, DateTime sourceMember, string? destMember, ResolutionContext context)
        {
            return sourceMember.DateToString(ConfigurationManager.LongDateFormat, tzTargetId: _tz);
        }

        public virtual string? Resolve(BaseEntity source, BaseModel destination, DateTime? sourceMember, string? destMember, ResolutionContext context)
        {
            if (sourceMember.HasValue)
            {
                return sourceMember.Value.DateToString(ConfigurationManager.LongDateFormat, tzTargetId: _tz);
            }
            else
            {
                return string.Empty;
            }
        }
    }
}
