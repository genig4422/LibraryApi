using Microsoft.EntityFrameworkCore;
using TestApplication.DataConnection.Models;

namespace TestApplication.DataConnection
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options) { }

      

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Book_Author>()
                .HasOne(b => b.Author)
                .WithMany(ba => ba.Book_Authors)
                .HasForeignKey(bi => bi.AuthorId);
            
            modelBuilder.Entity<Book_Author>()
             .HasOne(b => b.Book)
             .WithMany(ba => ba.Book_Authors)
             .HasForeignKey(bi => bi.BookId);


            modelBuilder.Entity<BorrowRecord>()
               .HasKey(br => br.Id); // Set primary key

            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Member)
                .WithMany(m => m.BorrowRecords)
                .HasForeignKey(br => br.MemberId);

            modelBuilder.Entity<BorrowRecord>()
                .HasOne(br => br.Book)
                .WithMany(b => b.BorrowRecords)
                .HasForeignKey(br => br.BookId);



            base.OnModelCreating(modelBuilder);
        }

       

        public DbSet<Book> Books { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<Book_Author> Books_Authors { get; set; }
        public DbSet<Author> Author { get; set; }
        public DbSet<BorrowRecord> BorrowRecords { get; set; }
        public DbSet<Members> Members { get; set; }
    }
}
