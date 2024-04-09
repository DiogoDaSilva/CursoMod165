using CursoMod165.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CursoMod165.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Tables
        public DbSet<Customer> Customers { get; set; } = default!;

        public DbSet<Staff> Staffs { get; set; } = default!;

        public DbSet<StaffRole> StaffRoles { get; set;} = default!;

        public DbSet<Appointment> Appointments { get; set; } = default!;
    }
}
