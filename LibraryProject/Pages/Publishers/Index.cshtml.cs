using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Publishers
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<Publisher> _publisherRepository;
        public ICollection<Publisher> Publishers { get; set; }

        public IndexModel(IRepository<Publisher> publisherRepository)
        {
            _publisherRepository = publisherRepository;
        }

        public void OnGet()
        {
            Publishers = _publisherRepository.GetQueryable().ToList();
        }
        public IActionResult OnGetDelete(long id)
        {
           var publisher = _publisherRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            _publisherRepository.Delete(publisher);
            return RedirectToPage("/Publishers/Index");
        }
    }
}
