using CK.Central.Core.DataObjects.Entity;
using Nest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Mapping
{
    public static class MappingElasticsearch
    {
        public static CreateIndexDescriptor BaseEntityMapping(this CreateIndexDescriptor descriptor)
        {
            return descriptor.Map<BaseEntity>(m => m.Properties(p => p
                .Keyword(k => k.Name(n => n.PK_UUID))
                .Keyword(k => k.Name(n => n.Parent_UUID))
                .Text(t => t.Name(n => n.Name))
                .Text(t => t.Name(n => n.Description))
                .Number(t => t.Name(n => n.Code))
                .Number(t => t.Name(n => n.IsActive))
                .Number(t => t.Name(n => n.IsDeleted))
                .Date(t => t.Name(n => n.CreatedBy))
                .Date(t => t.Name(n => n.CreatedDatetime))
                .Date(t => t.Name(n => n.UpdatedBy))
                .Date(t => t.Name(n => n.UpdatedDatetime))
                .Date(t => t.Name(n => n.DeletedBy))
                .Date(t => t.Name(n => n.DeletedDatetime))
                )
            );
        }
    }
}
