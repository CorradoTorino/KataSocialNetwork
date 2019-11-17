using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SocialNetworkWebApp.Models;

namespace SocialNetworkWebApp.Pages.Users
{
    public class IndexModel : PageModel
    {
        private readonly SocialNetworkWebApp.Data.SocialNetworkWebAppContext _context;

        public IndexModel(SocialNetworkWebApp.Data.SocialNetworkWebAppContext context)
        {
            _context = context;
        }

        public IList<User> User { get;set; }

        public async Task OnGetAsync()
        {
            User = await _context.User.ToListAsync();
        }
    }
}
