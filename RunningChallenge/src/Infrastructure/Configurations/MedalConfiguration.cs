using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configurations
{
    public class MedalConfiguration : IEntityTypeConfiguration<Medal>
    {
        public void Configure(EntityTypeBuilder<Medal> builder)
        {
            builder.HasOne(m => m.User)
                .WithMany(u => u.Medals)
                .HasPrincipalKey(m => m.Id);

            builder.HasOne(m => m.Marathon);
        }
    }
}
