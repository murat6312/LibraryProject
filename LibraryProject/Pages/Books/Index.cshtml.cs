using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Pages.Books
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Book> _bookRepository;

        public IndexModel(IRepository<Book> bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public ICollection<Book> BookList { get; set; }
        
        public void OnGet()
        {
           BookList = _bookRepository.GetQueryable().Include(x => x.Author).Include(x => x.Publisher).ToList();
        }

        public IActionResult OnGetDelete(long id)
        {
            var book = _bookRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            _bookRepository.Delete(book);
            return RedirectToPage();
        }
    }
}
