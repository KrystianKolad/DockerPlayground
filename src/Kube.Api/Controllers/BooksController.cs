using System;
using System.Threading.Tasks;
using Kube.Api.Models;
using Kube.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Kube.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : Controller
    {
        private readonly IRepository<Book> _repository;
        public BooksController(IRepository<Book> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok ( await _repository.GetAsync());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            return Ok ( await _repository.FindAsync(x=>x.Id.Equals(id)));
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Book model)
        {
            await _repository.AddAsync(model);
            return Ok ();
        }
    }
}