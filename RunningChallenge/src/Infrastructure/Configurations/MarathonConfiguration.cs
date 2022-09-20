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
    public class MarathonConfiguration : IEntityTypeConfiguration<Marathon>
    {
        public void Configure(EntityTypeBuilder<Marathon> builder)
        {
            builder.HasMany<User>(m => m.Members)
                .WithMany(u => u.Marathons);
        }
    }
}
