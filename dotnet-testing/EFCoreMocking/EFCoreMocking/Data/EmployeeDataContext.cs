using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using EFCoreMocking.Models;

namespace EFCoreMocking.Data
{
    public class EmployeeDBContext : DbContext
    {
        public EmployeeDBContext(DbContextOptions<EmployeeDBContext> options)
            : base(options)
        {
        }

        public EmployeeDBContext()
        {
        }

        public virtual DbSet<Employee> Employees { get; set; } = default!;
    }

}
