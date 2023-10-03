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
    public class FundAccountsConfig : IEntityTypeConfiguration<FundAccount>
    {
        public void Configure(EntityTypeBuilder<FundAccount> builder)
        {
            builder.HasData(
                    new FundAccount("Bolsa", "Alma"),
                    new FundAccount("Efectivo", "Omayra")
                );
        }
    }
}
