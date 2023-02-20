using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace UserApp
{
    class ApplicationContext : DbContext
    {
        public DbSet<User> UsersDB { get; set; }

        public ApplicationContext() : base("DefaultConnection") { }
    }
}
