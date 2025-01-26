using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interface
{
    public interface IUserService
    {
        public void CreateUserService(string id, string name, string mail);
        public Task<IEnumerable<UserModel>> ReadAllUserRepository();
        public object ReadUserService(string id);
        public string UpdateUserService(string id, string? name, string? mail);
        public string DeleteUserService(string id);
    }
}
