using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie3.Data.SQL.DAO;

namespace zadanie3.Data.SQL.DAOConfigurations
{
    public class ZamowieniaConfiguration: IEntityTypeConfiguration<Zamowienia>
    {
        public void Configure(EntityTypeBuilder<Zamowienia> builder)
        {
            builder.Property(c => c.DataZlozeniaZamowienia).IsRequired();
            builder.HasOne(x => x.User)
                .WithMany(x => x.Zamowienie)
                .HasForeignKey(x => x.Uzytkownikid)
                .OnDelete(DeleteBehavior.Cascade);
            builder.ToTable("Zamowienia");
        }
    }
}