namespace test
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model1")
        {
        }

        public virtual DbSet<Executea> Executeas { get; set; }
        public virtual DbSet<HisData> HisDatas { get; set; }
        public virtual DbSet<RealData> RealDatas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Executea>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.TagValue)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.TagUint)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.TagDesc)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.UpdateTime)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.Flag)
                .IsUnicode(false);

            modelBuilder.Entity<Executea>()
                .Property(e => e.ExecuteTime)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.TagValue)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.TagUint)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.TagDesc)
                .IsUnicode(false);

            modelBuilder.Entity<HisData>()
                .Property(e => e.UpdateTime)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.Tag)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.TagValue)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.ProjectID)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.TagUint)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.TagDesc)
                .IsUnicode(false);

            modelBuilder.Entity<RealData>()
                .Property(e => e.UpdateTime)
                .IsUnicode(false);
        }
    }
}
