using BusinessLogic.Domain.Aggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.Persistence.Config
{
    public class BagFundValueConfig : IEntityTypeConfiguration<BagFundValue>
    {
        private readonly decimal hourValue = 500;
        public void Configure(EntityTypeBuilder<BagFundValue> builder)
        {
            builder.HasData(
                    new BagFundValue(hourValue)
                );
        }
    }
}
