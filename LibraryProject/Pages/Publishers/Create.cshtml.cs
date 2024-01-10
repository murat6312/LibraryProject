using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Publishers
{
    public class CreateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public PublisherDto PublisherDto { get; set; }

        public CreateModel(ILogger<CreateModel> logger, IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            this.logger = logger;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }


        public void OnGet()
        {
        }

        public IActionResult OnPost(PublisherDto publisherDto)
        {
            var publisher = _mapper.Map<Publisher>(publisherDto);
            _publisherRepository.Add(publisher);
            return RedirectToPage("/Publishers/Index");
        }
    }
}
