using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Kube.Web.Models;
using RestEase;

namespace Kube.Web.Services
{

    [SerializationMethods(Query = QuerySerializationMethod.Serialized)]
    public interface IBookService
    {
        [Get]
        Task<IEnumerable<Book>> GetAll();

        [Get("{id}")]
        Task<IEnumerable<Book>> Find([Path]Guid id);

        [Post]
        Task<IEnumerable<Book>> Post([Body]Book book);
    }
}