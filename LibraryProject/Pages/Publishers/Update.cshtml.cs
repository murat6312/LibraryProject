using AutoMapper;
using Core.Models;
using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Publishers
{
    public class UpdateModel : PageModel
    {
        private readonly ILogger<CreateModel> logger;
        private readonly IRepository<Publisher> _publisherRepository;
        private readonly IMapper _mapper;
        [BindProperty]
        public PublisherDto PublisherDto { get; set; }

        public UpdateModel(ILogger<CreateModel> logger, IRepository<Publisher> publisherRepository, IMapper mapper)
        {
            this.logger = logger;
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }


        public void OnGet(long id)
        {
            var publisher = _publisherRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            PublisherDto = new PublisherDto();
            _mapper.Map(publisher, PublisherDto);
        }

        public IActionResult OnPost(PublisherDto publisherDto)
        {
            var publisher = _publisherRepository.GetQueryable().FirstOrDefault(x => x.Id == publisherDto.Id);
            _mapper.Map(publisherDto, publisher);
            _publisherRepository.Update(publisher);
            return RedirectToPage("/Publishers/Index");
        }
    }
}
