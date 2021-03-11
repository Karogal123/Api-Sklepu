using zadanie3.Data.SQL.DAO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace zadanie3.Data.SQL.DAOConfigurations
{
    public class AutorzyConfiguration: IEntityTypeConfiguration<Autorzy>
    {
        public void Configure(EntityTypeBuilder<Autorzy> builder)
        {
            builder.Property(c => c.Imie).IsRequired();
            builder.Property(c => c.Nazwisko).IsRequired();
            builder.ToTable("Autorzy");
        }
    }
}