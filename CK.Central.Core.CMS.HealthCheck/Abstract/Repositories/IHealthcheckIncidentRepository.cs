using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.Domain.DataObjects.Shared.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.CMS.HealthCheck.Abstract.Repositories
{
    public interface IHealthcheckIncidentRepository : IBaseRepository<HealthcheckIncidentEntity>
    {
    }
}
