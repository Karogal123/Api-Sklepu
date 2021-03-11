using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie3.Data.SQL.DAO;
namespace zadanie3.Data.SQL.DAOConfigurations
{
    public class PlanszowkiConfiguration: IEntityTypeConfiguration<Planszowki>
    {
        public void Configure(EntityTypeBuilder<Planszowki> builder)
        {
            builder.Property(c => c.Nazwa).IsRequired();
            builder.Property(c => c.Typ).IsRequired();
            builder.Property(c => c.IloscGraczy).IsRequired();
            builder.Property(c => c.Cena).IsRequired();
            builder.Property(c => c.CzasGry).IsRequired();
            builder.Property(c => c.Wiek).IsRequired();
            builder.Property(c => c.Wydanie).IsRequired();
            builder.ToTable("Planszowki");
        }
    }
}