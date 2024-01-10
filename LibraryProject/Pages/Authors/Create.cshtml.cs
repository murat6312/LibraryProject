using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Authors
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public AuthorDto AuthorDto { get; set; }
        private readonly IRepository<Author> _authorRepository;
        private readonly ILogger<CreateModel> _logger;
        private readonly IMapper _mapper;

        public CreateModel(IRepository<Author> authorRepository, ILogger<CreateModel> logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost( AuthorDto authorDto)
        {
           var author = _mapper.Map<Author>(authorDto);
            _authorRepository.Add(author);
            return RedirectToPage("/Authors/Index");
        }
    }
}
