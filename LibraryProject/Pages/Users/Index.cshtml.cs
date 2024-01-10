using DataAcces.Entity;
using DataAcces.Repositorys;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace LibraryProject.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly IRepository<User> _userRepository;

        public IndexModel(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }

        public ICollection<User> Users { get; set; }
        public void OnGet()
        {
            Users = _userRepository.GetQueryable().ToList();
        }

        public IActionResult OnGetDelete(long id)
        {
           var user = _userRepository.GetQueryable().FirstOrDefault(x => x.Id == id);
            _userRepository.Delete(user);
            return RedirectToPage();
        }
    }
}
