using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Pages.Books
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public BookUpdateModel BookUpdateModel { get; set; }

        public List<SelectListItem> AuthorListItem = new List<SelectListItem>();

        public List<SelectListItem> PublisherListItem = new List<SelectListItem>();

        public CreateModel(IRepository<Book> bookRepository, IRepository<Author> authorRepository, IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public void OnGet()
        {
            SetterAuthorListItem();
            SetterPublisherListItem();
        }

        public IActionResult OnPost(BookUpdateModel bookUpdateModel)
        {
            var book = _mapper.Map<Book>(bookUpdateModel);
            if (book == null)
            {
                return NotFound();
            }
            _bookRepository.Add(book);
            TempData["succes"] = "Baþarýlýyla eklendi";
            return RedirectToPage("/Books/Index");
        }

        private void SetterAuthorListItem() 
        {
            var authors = _authorRepository.GetQueryable().ToList();
            foreach (var author in authors) {
                var selectItem = new SelectListItem();
                selectItem.Text = author.FullName;
                selectItem.Value = author.Id.ToString();
                AuthorListItem.Add(selectItem);
            }
        }

        private void SetterPublisherListItem()
        {
           var publishers = _publisherRepository.GetQueryable().ToList();
            foreach (var author in publishers)
            {
                var selectItem = new SelectListItem();
                selectItem.Text = author.Name;
                selectItem.Value = author.Id.ToString();
                PublisherListItem.Add(selectItem);
            }
        }
    }
}
