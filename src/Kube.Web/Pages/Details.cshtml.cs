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
    public class DetailsModel : PageModel
    {
        private IBookService _service;
        public Book Book { get; set; }
        public DetailsModel(IBookService service)
        {
            _service = service;
        }
        public async Task OnGetAsync(Guid id)
        {
            Book = await _service.Find(id);
        }
    }
}