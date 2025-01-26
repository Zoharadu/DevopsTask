using Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IUserRepository
    {
        public void CreateUserRepository(string id, string name, string mail);
        public Task<IEnumerable<UserModel>> ReadAllUserRepository();
        public object ReadUserRepository(string id);
        public string UpdateUserRepository(string id, string? name, string? mail);
        public string DeleteUserRepository(string id);
    }
}
