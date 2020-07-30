using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HPMS.Models
{
    public class MainDBContext : DbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Drug> Drugs { get; set; }
    }
}