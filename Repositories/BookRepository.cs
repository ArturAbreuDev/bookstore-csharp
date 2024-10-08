using apibookstore.context;
using apibookstore.entities.models;
using Microsoft.EntityFrameworkCore;

namespace apibookstore.Repositories
{
    public class BookRepository : IBookRepository
    {    
        private readonly BookstoreContext _context;

        public BookRepository(BookstoreContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync() => await _context.Books.ToListAsync();
        public async Task<Book> GetByIdAsync(int Id) => await _context.Books.FindAsync(Id);
        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int Id)
        {
            var book = await GetByIdAsync(Id);
            if(book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
        }
         
    }
}