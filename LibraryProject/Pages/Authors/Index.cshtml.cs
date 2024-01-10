using AutoMapper;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Authors
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Author> _authorRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public ICollection<Author> AuthorList { get; set; }

        public IndexModel(IRepository<Author> authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public void OnGet()
        {
            AuthorList = _authorRepository.GetQueryable().ToList();
        }

        public IActionResult OnGetDelete(long id)
        {
            var author = _authorRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            _authorRepository.Delete(author);
            return RedirectToPage();
        }
    }
}
