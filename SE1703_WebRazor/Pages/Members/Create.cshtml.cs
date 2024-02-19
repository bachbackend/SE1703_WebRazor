using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using SE1703_WebRazor.Models;

namespace SE1703_WebRazor.Pages.Members
{
    public class CreateModel : PageModel
    {
        private readonly SE1703_WebRazor.Models.EStoreContext _context;
        private readonly IHubContext<SignalRServer> _signalRHub;

        public CreateModel(SE1703_WebRazor.Models.EStoreContext context, IHubContext<SignalRServer> signalRHub)
        {
            _context = context;
            _signalRHub = signalRHub;

        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Member Member { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Members == null || Member == null)
            {
                return Page();
            }

            _context.Members.Add(Member);
            await _context.SaveChangesAsync();
            //         await _signalRHub.Clients.All.SendAsync("LoadCategories");

            return RedirectToPage("./Index");
        }


    }
}
