using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace LibraryProject.Pages.BookRents
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<BookRent>bookRentRepository;

        public ICollection<BookRent> BookRent { get; set; }
        public IndexModel(IRepository<BookRent> bookRentRepository)
        {
            this.bookRentRepository = bookRentRepository;
        }
        public void OnGet()
        {
            BookRent = bookRentRepository.GetQueryable().Include(x => x.User).Include(x => x.Book).ToList();
        }

        public IActionResult OnGetDelete(long id)
        {
            var bookRent = bookRentRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            bookRentRepository.Delete(bookRent);
            return RedirectToPage();
        }
    }
}
