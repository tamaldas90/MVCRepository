using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Bookshop.Models;
using System.Data.Entity;
using System.Data;


namespace Bookshop.DAL
{
    public class BookRepository : IBookRepository,IDisposable
    {
        private StoryBookDbcontext _context;

        public BookRepository(StoryBookDbcontext bookContext)
        {
            this._context = bookContext;
        }

        public IEnumerable<StoryBook> GetBooks()
        {
            return _context.Books.ToList();
        }

        public StoryBook GetBookByID(int id)
        {
            return _context.Books.Find(id);
        }

        public void InsertBook(StoryBook book)
        {
            _context.Books.Add(book);
        }

        public void DeleteBook(int bookID)
        {
            StoryBook book = _context.Books.Find(bookID);
            _context.Books.Remove(book);
        }

        public void UpdateBook(StoryBook book)
        {
            _context.Entry(book).State = EntityState.Modified;
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}