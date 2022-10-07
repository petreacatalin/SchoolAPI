using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Data.Configuration.Entities
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Student",
                    NormalizedName = "STUDENT"

                },
                new IdentityRole
                {
                    Name = "Professor",
                    NormalizedName = "PROFESSOR"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "MANAGER"
                });

        }
    }
}
