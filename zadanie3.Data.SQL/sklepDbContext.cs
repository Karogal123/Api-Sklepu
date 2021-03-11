using Microsoft.EntityFrameworkCore;
using zadanie3.Data.SQL.DAO;
using zadanie3.Data.SQL.DAOConfigurations;

namespace zadanie3.Data.SQL
{
    public class SklepDbContext : DbContext
    {
        public SklepDbContext(DbContextOptions<SklepDbContext> options) : base(options) {}
        
        public virtual DbSet<Autorzy> Autorzy { get; set; }        
        public virtual DbSet<User> User { get; set; }        
        public virtual DbSet<Zamowienia> Zamowienia { get; set; }        
        public virtual DbSet<Planszowki> Planszowki { get; set; }        
        public virtual DbSet<AutorzyPlanszowek> AutorzyPlanszowek { get; set; }        
        public virtual DbSet<ZamowieniaPlanszowek> ZamowieniaPlanszowek { get; set; }        
       
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AutorzyConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ZamowieniaConfiguration());
            builder.ApplyConfiguration(new PlanszowkiConfiguration());
            builder.ApplyConfiguration(new AutorzyPlanszowekConfiguration());
            builder.ApplyConfiguration(new ZamowieniaPlanszowekConfiguration());
        }
    }
}