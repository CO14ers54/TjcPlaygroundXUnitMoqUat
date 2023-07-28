using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjcPlaygroundXUnitMoqUat
{
    public record User(string firstName, string lastName)
    {
        public int Id { get; set; }
        public DateTime CreateDate { get; set; } = DateTime.UtcNow;
        public string Phone { get; set; }
        public bool VerifiedEmail { get; set; } = false;
    }

    public class UserManagement
    {
        private readonly List<User> m_users = new();

        private int IdCounter = 1;

        public IEnumerable<User> AllUsers => m_users;

        public void Add(User user)
        {
            m_users.Add(user with { Id = IdCounter++ });
        }

        public void UpdatePhone(User user)
        {
            var dbUser = m_users.First(x => x.Id== user.Id);
        
            dbUser.Phone = user.Phone;  
        }

        public void VerifyEmail(int userId)
        {
            var dbUser = m_users.First(x => x.Id == userId);

            dbUser.VerifiedEmail = true;

        }
    }
}
