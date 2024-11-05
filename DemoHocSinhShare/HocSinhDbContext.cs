using DemoHocSinhShare.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoHocSinhShare
{
    public class HocSinhDbContext : DbContext
    {
        public HocSinhDbContext(DbContextOptions<HocSinhDbContext> options) : base(options) { }

        public DbSet<HocSinh> HocSinhs { get; set; }
    }
}
