using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CK.Central.Core.DataObjects.Entity;
using Nest;

namespace CK.Central.Core.Abstract.Services
{
    public interface IElasticsearchBaseService
    {
        Task ChekIndex(string indexName);
        Task InsertDocument(string indexName, BaseEntity entity);
        Task DeleteIndex(string indexName);
        Task DeleteByIdDocument(string indexName, BaseEntity entity);
        Task InsertBulkDocuments(string indexName, List<BaseEntity> entities);
        Task<BaseEntity> GetDocument(string indexName, string id);
        Task<List<BaseEntity>> GetDocuments(string indexName);
    }
}
