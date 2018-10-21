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
        Task<IList<Book>> GetAll();

        [Get("{id}")]
        Task<Book> Find([Path]Guid id);

        [Post]
        Task Add([Body]Book book);
    }
}