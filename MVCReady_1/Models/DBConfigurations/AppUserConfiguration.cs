using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MVCReady_1.Models.Entities;

namespace MVCReady_1.Models.DBConfigurations
{
    public class AppUserConfiguration:BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);  //Base'deki görev kalsın

            builder.HasOne(x => x.Profile).WithOne(x => x.AppUser).HasForeignKey<UserProfile>(x => x.ID);
        }
    }
}
