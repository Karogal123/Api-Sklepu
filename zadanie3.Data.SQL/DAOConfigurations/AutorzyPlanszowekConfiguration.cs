using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using zadanie3.Data.SQL.DAO;

namespace zadanie3.Data.SQL.DAOConfigurations
{
    public class AutorzyPlanszowekConfiguration: IEntityTypeConfiguration<AutorzyPlanszowek>
    {
        public void Configure(EntityTypeBuilder<AutorzyPlanszowek> builder)
        {
            builder.HasOne(x => x.Autorzy)
                .WithMany(x => x.AutorPlanszowek)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.Autorid);
            builder.HasOne(x => x.Planszowki)
                .WithMany(x => x.AutorPlanszowek)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey(x => x.Planszowkaid);
            builder.ToTable("AutorzyPlanszowek");
               
        }
    }
    }
