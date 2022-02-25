using Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Seeds
{
    public class UsageStatusSeed : IEntityTypeConfiguration<UsageStatus>
    {
        

        public void Configure(EntityTypeBuilder<UsageStatus> builder)
        {
            builder.HasData(new UsageStatus { Id=1,Name="Etiketli",CreatedDate=DateTime.Now});
        }
    }
}
