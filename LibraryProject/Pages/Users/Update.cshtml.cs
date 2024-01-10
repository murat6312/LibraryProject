using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Users
{
    public class UpdateModel : PageModel
    {
        private readonly IRepository<User> _userRepository;
        [BindProperty]
        public User User { get; set; }

        public UpdateModel(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public void OnGet(long id)
        {
            User = _userRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
        }

        public IActionResult OnPost(User user)
        {
            _userRepository.Update(user);
            return RedirectToPage("/Users/Index");
        }

    }
}
