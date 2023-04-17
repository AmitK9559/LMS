using Library.Models;
using Microsoft.EntityFrameworkCore;
namespace Library.DBContext
{
    public class ResultDB : DbContext
    {
        public ResultDB(DbContextOptions<ResultDB> options)
            : base(options)
        {

        }
        public DbSet<AdminLogin> AdminLog { get; set;}

        public DbSet<Student> Student { get; set; }
    }
}
