using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CIDM3312_Star_Wars.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CIDM3312_Star_Wars.Pages.Characters
{
    public class IndexModel : PageModel
    {
        private readonly CIDM3312_Star_Wars.Models.Context _context;

        public IndexModel(CIDM3312_Star_Wars.Models.Context context)
        {
            _context = context;
        }

        public IList<Character> Character { get;set; } = default!;

        // Creating a page number and size to allow for paging
        [BindProperty(SupportsGet = true)]
        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;

        // Creating sort lists to allow the user to sort the data on the web page
        [BindProperty(SupportsGet = true)]
        public string CurrentSort {get; set;} = string.Empty;
        public SelectList SortList {get; set;} = default!;

        public async Task OnGetAsync(string searchString)
        {
            if (_context.Character != null)
            {
                // basic query to bring all characters in
                var query = _context.Character.Select(c => c);
                
                // Creating asecnding and descending sort
                List<SelectListItem> sortItems = new List<SelectListItem> {
                    new SelectListItem { Text = "Name Ascending", Value = "first_asc" },
                    new SelectListItem { Text = "Name Descending", Value = "first_desc"}
                };
                SortList = new SelectList(sortItems, "Value", "Text", CurrentSort);

                switch (CurrentSort)
                {
                    // query to sort by first name ascending order
                    case "first_asc": 
                        query = query.OrderBy(p => p.Name);
                        break;
                    // query to sort by first name descending
                    case "first_desc":
                        query = query.OrderByDescending(p => p.Name);
                        break;
                }
                    // Search related string that will search query for user input
                    if (!String.IsNullOrEmpty(searchString))
                    {
                        query = query.Where(s => s.Name.Contains(searchString));
                    }

                // Paging for web page based on pagenumber and page size
                Character = await query.Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
            }
        }
    }
}
