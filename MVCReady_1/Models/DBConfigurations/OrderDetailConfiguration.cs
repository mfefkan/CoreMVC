using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCReady_1.Models.Entities;

namespace MVCReady_1.Models.DBConfigurations
{
    public class OrderDetailConfiguration:BaseConfiguration<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.Ignore(x => x.ID);

            builder.HasKey(x=> new 
            {
                x.OrderID,
                x.ProductID

            });
        }
    }
}
