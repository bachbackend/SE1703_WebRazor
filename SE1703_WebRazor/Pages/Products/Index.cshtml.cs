using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SE1703_WebRazor.Models;

namespace SE1703_WebRazor.Pages.Products
{
    public class IndexModel : PageModel
    {
        private readonly SE1703_WebRazor.Models.eStoreContext _context;

        public IndexModel(SE1703_WebRazor.Models.eStoreContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        [BindProperty]
        public string id { get; set; }
        public async Task OnGetAsync(int id)
        {
            if (_context.Products != null)
            {
                Product = await _context.Products
                .Include(p => p.Category).ToListAsync();
            }
        }

        
    }
}
