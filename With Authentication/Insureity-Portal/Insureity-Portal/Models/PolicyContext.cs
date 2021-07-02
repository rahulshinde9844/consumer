using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Insureity_Portal.Models
{
    public class PolicyContext : DbContext
    {
        public PolicyContext(DbContextOptions<PolicyContext> options)
        : base(options) { }

        public DbSet<Models.ConsumerBusiness> ConsumerBusinessesDb { get; set; }

        public DbSet<Models.BusinessProperty> BusinessPropertyDb { get; set; }

        //public DbSet<Models.ConsumerBusinessDetails> ConsumerBusinessesAlldb { get; set; }

        //public DbSet<Models.BusinessPropertyDetails> BusinessPropertyAlldb { get; set; }

    }
}
