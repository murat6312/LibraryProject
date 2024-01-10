using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Users
{
    public class CreateModel : PageModel
    {
        private readonly IRepository<User> _userRepository;

        [BindProperty]
        public User User { get; set; }

        public CreateModel(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet()
        {
        }

        public IActionResult OnPost(User user)
        {
            _userRepository.Add(user);
            return RedirectToPage("/Users/Index");
        }
    }
}
