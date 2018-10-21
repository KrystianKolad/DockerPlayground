using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kube.Web.Models;
using Kube.Web.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Kube.Web.Pages
{
    public class AddModel : PageModel
    {
        private IBookService _service;
        [BindProperty]
        public Book Book { get; set; }
        public AddModel(IBookService service)
        {
            _service = service;
        }
        public void OnGet()
        {
            Book = new Book();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            await _service.Add(Book);

            return RedirectToPage("/Index");
        }
    }
}