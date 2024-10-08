using apibookstore.entities.models;
using Microsoft.EntityFrameworkCore;

namespace apibookstore.context
{
    public class BookstoreContext : DbContext
    {

    public BookstoreContext (DbContextOptions<BookstoreContext> options) : base(options) {}
    public DbSet<Book> Books  { get; set; }
    }
}