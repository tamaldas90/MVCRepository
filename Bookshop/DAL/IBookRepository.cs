using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bookshop.Models;

namespace Bookshop.DAL
{
    interface IBookRepository : IDisposable
    {

        IEnumerable<StoryBook> GetBooks();
        StoryBook GetBookByID(int bookId);
        void InsertBook(StoryBook book);
        void DeleteBook(int bookID);
        void UpdateBook(StoryBook book);
        void Save();
    }
}
