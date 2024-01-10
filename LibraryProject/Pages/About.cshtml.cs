using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages
{
    public class PrivacyModel : PageModel
    {
        private readonly ILogger<PrivacyModel> _logger;
        private readonly IRepository<Publisher> _bookRepository;

        public PrivacyModel(ILogger<PrivacyModel> logger, IRepository<Publisher> bookRepository)
        {
            _logger = logger;
            _bookRepository = bookRepository;
        }

        public void OnGet()
        {
        }
    }
}