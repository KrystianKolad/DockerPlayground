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
    public class IndexModel : PageModel
    {
        private IBookService _service;
        public IEnumerable<Book> Books { get; set; }
        public IndexModel(IBookService service)
        {
            _service = service;
        }
        public async Task OnGetAsync()
        {
            Books = await _service.GetAll();
        }
    }
}
