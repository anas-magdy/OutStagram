namespace OutSagram.Models
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB1")
        {
        }

        public virtual DbSet<friendRelation> friendRelation { get; set; }
        public virtual DbSet<post> post { get; set; }
        public virtual DbSet<user> user { get; set; }
        public virtual DbSet<comment> comment{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<post>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.post)
                .HasForeignKey(e => e.post_id)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasOptional(e => e.friendRelation)
                .WithRequired(e => e.user);

            modelBuilder.Entity<user>()
                .HasMany(e => e.posts)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.autherID)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<user>()
                .HasMany(e => e.comments)
                .WithRequired(e => e.user)
                .HasForeignKey(e => e.user_id_comment)
                .WillCascadeOnDelete(false);
        }
    }
}
