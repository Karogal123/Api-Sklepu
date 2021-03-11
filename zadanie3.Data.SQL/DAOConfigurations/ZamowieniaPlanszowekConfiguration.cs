using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie3.Data.SQL.DAO;

namespace zadanie3.Data.SQL.DAOConfigurations
{
    public class ZamowieniaPlanszowekConfiguration: IEntityTypeConfiguration<ZamowieniaPlanszowek>
    {
        public void Configure(EntityTypeBuilder<ZamowieniaPlanszowek> builder)
        {
            builder.HasOne(x => x.Zamowienia)
                .WithMany(x => x.ZamowieniePlanszowek)
                .HasForeignKey(x => x.Zamowienieid)
                .OnDelete(DeleteBehavior.Cascade);
            builder.HasOne(x => x.Planszowki)
                .WithMany(x => x.ZamowieniePlanszowek)
                .HasForeignKey(x => x.Planszowkaid)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("ZamowieniaPlanszowek");
        }
    }
}