using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Pages.BookRents
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<BookRent> _bookRentRepository;
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<User> _userRepository;


        [BindProperty]
        public BookRent BookRent { get; set; }

        public List<SelectListItem> UserListItem { get; set; } = new List<SelectListItem>();
        [BindProperty]
        public List<SelectListItem> BookListItem { get; set; } = new List<SelectListItem>();

        public CreateModel(IRepository<BookRent> bookRentRepository, IRepository<Book> bookRepository, IRepository<User> userRepository)
        {
            _bookRentRepository = bookRentRepository;
            _bookRepository = bookRepository;
            _userRepository = userRepository;
        }

        public void OnGet()
        {
            SetterUserListItem();
            SetterBookListItem();
        }

        public IActionResult OnPost(BookRent bookRent)
        {
            SetterUserListItem();
            SetterBookListItem();
            _bookRentRepository.Add(bookRent);
            return RedirectToPage("/BookRents/Index");
        }

        private void SetterBookListItem()
        {
            var books = _bookRepository.GetQueryable().ToList();
            foreach (var book in books)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = book.Name;
                selectItem.Value = book.Id.ToString();
                BookListItem.Add(selectItem);
            }
        }

        private void SetterUserListItem()
        {
            var users = _userRepository.GetQueryable().ToList();
            foreach (var user in users)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = user.Name;
                selectItem.Value = user.Id.ToString();
                UserListItem.Add(selectItem);
            }
        }
    }
}
