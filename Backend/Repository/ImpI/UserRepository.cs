using Common;
using Devops.Data;
using Repository.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.ImpI
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public void CreateUserRepository(string id, string name, string mail)
        {
            try
            {
                var user = new UserModel
                {
                    id = id,
                    name = name,
                    mail = mail
                };

                _context.Users.Add(user);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to create user: " + ex.Message);
            }
        }

        public async Task<IEnumerable<UserModel>> ReadAllUserRepository()
        {
            try
            {
                return await _context.Users
                .Select(user => new UserModel
                {
                    id = user.id.ToString(),
                    name = user.name,
                    mail = user.mail
                })
                .ToListAsync();
            }
            catch (Exception ex)
            {
                throw (ex);
            }
        }

        public object ReadUserRepository(string id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.id == id);
                if (user == null)
                {
                    return ($"User with ID {id} not found.");
                }
                return user;
            }
            catch (Exception ex)
            {
                throw new Exception("Failed to read user: " + ex.Message);
            }
        }

        public string UpdateUserRepository(string id, string? name, string? mail)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.id == id);
                if (user == null)
                {
                    throw new ($"User with ID {id} not found.");
                }

                if (!string.IsNullOrEmpty(name))
                {
                    user.name = name;
                }

                if (!string.IsNullOrEmpty(mail))
                {
                    user.mail = mail;
                }

                _context.SaveChanges(); 
                return ($"User with ID {id} has been updated.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to update user: {ex.Message}");
            }
        }

        public string DeleteUserRepository(string id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.id == id);
                if (user == null)
                {
                    return ($"User with ID {id} not found.");
                }

                _context.Users.Remove(user); // הסרה מה-DbSet
                _context.SaveChanges(); // שמירת השינויים בבסיס הנתונים
                return ($"User with ID {id} has been deleted.");
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete user: {ex.Message}");
            }
        }
    }
}
