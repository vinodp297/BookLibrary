using BookLibraryManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BookLibraryManager.DataAccess.Data
{
    public class LibraryDBContext : DbContext
    {

        public LibraryDBContext(DbContextOptions<LibraryDBContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

    }
}
