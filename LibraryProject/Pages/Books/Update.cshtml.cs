using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Pages.Books
{
    public class UpdateModel : PageModel
    {
        private readonly IRepository<Book> _bookRepository;
        private readonly IRepository<Author> _authorRepository;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public BookUpdateModel BookUpdateModel { get; set; }
        [BindProperty]
        public List<SelectListItem> AuthorListItem { get; set; } = new List<SelectListItem>();
        [BindProperty]
        public List<SelectListItem> PublisherListItem { get; set; } = new List<SelectListItem>();

        public UpdateModel(IRepository<Book> bookRepository, IRepository<Author> authorRepository, IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public void OnGet(long id)
        {
            SetterPublisherListItem();
            SetterAuthorListItem();
            var book = _bookRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            BookUpdateModel = new BookUpdateModel();
            _mapper.Map(book, BookUpdateModel);
            
        }

        public IActionResult OnPost(BookUpdateModel bookUpdateModel) 
        {
            SetterAuthorListItem();
            SetterPublisherListItem();
            var book = _bookRepository.GetQueryable().FirstOrDefault(x => x.Id == bookUpdateModel.Id);
            if(book == null)
            {
                return NotFound();
            }
            _mapper.Map(bookUpdateModel, book);
            _bookRepository.Update(book);
            return RedirectToPage("/Books/Index");
        }

        private void SetterAuthorListItem()
        {
            var authors = _authorRepository.GetQueryable().ToList();
            foreach (var author in authors)
            {
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
