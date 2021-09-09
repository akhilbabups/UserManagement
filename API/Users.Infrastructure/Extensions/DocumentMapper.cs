using System.Collections.Generic;
using System.Linq;
using Users.Domain.Extensions;
using Users.Infrastructure.MDO;

namespace Users.Infrastructure.Extensions
{
    public static class DocumentMapper
    {
        #region TO DOCUMENT
        public static UserDocument ToDocument(this Users.Domain.Models.User user)
        {
            return new UserDocument
            {
                Id = user.Id,
                FullName = user.FullName,
                Roles = user.Roles.ToDocumentCollection()
            };
        }

        private static IEnumerable<Role> ToDocumentCollection(this IEnumerable<Users.Domain.Models.Role> roles)
        {
            if (roles.IsNullOrEmptyCollection())
            {
                return Enumerable.Empty<Role>();
            }

            return roles.Select(role => role.ToDocument());
        }

        private static Role ToDocument(this Users.Domain.Models.Role user)
        {
            return new Role
            {
                Name = user.Name
            };
        }
        #endregion TO DOCUMENT

        #region TO MODEL
        public static IEnumerable<Users.Domain.Models.User> ToModel(this IEnumerable<UserDocument> users)
        {
            if (users.IsNullOrEmptyCollection())
            {
                return Enumerable.Empty<Users.Domain.Models.User>();
            }

            return users.Select(user => user.ToModel());
        }

        public static Users.Domain.Models.User ToModel(this UserDocument user)
        {
            if (user == null)
                return null;

            return new Users.Domain.Models.User
            {
                Id = user.Id,
                FullName = user.FullName,
                Roles = user.Roles.ToRoleModel()
            };
        }

        private static IEnumerable<Users.Domain.Models.Role> ToRoleModel(this IEnumerable<Role> roles)
        {
            if (roles.IsNullOrEmptyCollection())
            {
                return Enumerable.Empty<Users.Domain.Models.Role>();
            }

            return roles.Select(role => role.ToModel());
        }

        private static Users.Domain.Models.Role ToModel(this Role user)
        {
            return new Users.Domain.Models.Role
            {
                Name = user.Name
            };
        }
        #endregion TO MODEL
        //public static IEnumerable<TM> ToModelCollectiom<TD,TM>(this IEnumerable<TD> collection)
        //{
        //    if(collection.IsNullOrEmptyCollection())
        //    {
        //        return Enumerable.Empty<TM>();
        //    }
        //    return collection.Select(d => d.ToModel<TD>());

        //}
    }
}
