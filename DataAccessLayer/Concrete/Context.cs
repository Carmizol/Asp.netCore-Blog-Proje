using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class Context : IdentityDbContext<AppUser,AppRole,int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer("server=BS-BGN-0020\\MSSQLSERVER01;database=DbCore; integrated security=true;");
            //optionsBuilder.UseSqlServer("server=BS-BGN-0020\\MSSQLSERVER01;database=DbCore;integrated security=true;Encrypt=True;user=sa");
            optionsBuilder.UseSqlServer("Server=BS-BGN-0020\\MSSQLSERVER01;Database=DbCore;User Id=sa;Password=12345;TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MessageRelation>()
                .HasOne(x => x.SenderUser)
                .WithMany(y => y.WriterSender)
                .HasForeignKey(z => z.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            modelBuilder.Entity<MessageRelation>()
                .HasOne(x => x.RecieverUser)
                .WithMany(y => y.WriterReceiver)
                .HasForeignKey(z => z.RecevierId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Writer> Writers { get; set; }
        public DbSet<NewsLetter> NewsLetters { get; set; }
        public DbSet<RaytingShare> RaytingShares { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<MessageRelation> messageRelations { get; set; }
        public DbSet<Admin> Admins { get; set; }
    }
}
