using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryProject.Pages.Authors
{
    public class UpdateModel : PageModel
    {
        [BindProperty]
        public AuthorDto AuthorDto { get; set; }
        private readonly IRepository<Author> _authorRepository;
        private readonly ILogger<CreateModel> _logger;
        private readonly IMapper _mapper;

        public UpdateModel(IRepository<Author> authorRepository, ILogger<CreateModel> logger, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public void OnGet(long id)
        {
            var author = _authorRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            AuthorDto = new AuthorDto();
            _mapper.Map(author, AuthorDto);
        }

        public IActionResult OnPost(AuthorDto authorDto)
        {
            var author = _authorRepository.GetQueryable().FirstOrDefault(x => x.Id == authorDto.Id);
            _mapper.Map(authorDto, author);
            _authorRepository.Update(author);
            return RedirectToPage("/Authors/Index");
        }
    }
}
