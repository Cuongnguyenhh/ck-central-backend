using CK.Central.Core.Abstract.Repositories;
using CK.Central.Core.DataObjects.Dto;
using CK.Central.Core.DataObjects.Entity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Controllers
{
    public abstract class ControllerEntityBase<T> : ControllerBase
        where T : BaseEntity
    {
        protected readonly IBaseRepository<T> Repos;
        protected string? CurrentUserId => User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="repos"></param>
        protected ControllerEntityBase(IBaseRepository<T> repos)
        {
            Repos = repos;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Insert")]
        public virtual async Task<IActionResult> Insert([FromBody] T obj)
        {
            await Repos.Insert(obj);
            Repos.UOW.Commit();
            return Ok(BaseResponseDto.Succeed(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Update")]
        public virtual async Task<IActionResult> Update([FromBody] T obj)
        {
            await Repos.Update(obj);
            Repos.UOW.Commit();
            return Ok(BaseResponseDto.Succeed(obj));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("Delete")]
        public virtual async Task<IActionResult> Delete([FromBody] T obj)
        {
            await Repos.Delete(obj.PK_UUID, string.IsNullOrEmpty(obj.DeletedBy) ? string.Empty : obj.DeletedBy);
            Repos.UOW.Commit();
            return Ok(BaseResponseDto.Succeed(obj.PK_UUID));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("Get")]
        public virtual async Task<IActionResult> Get([FromQuery] Guid id)
        {
            return Ok(BaseResponseDto.Succeed(await Repos.FindById(id)));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAll")]
        public virtual async Task<IActionResult> GetAll()
        {
            return Ok(BaseResponseDto.Succeed(await Repos.GetAll()));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("GetAllIsActive")]
        public virtual async Task<IActionResult> GetAllIsActive()
        {
            return Ok(BaseResponseDto.Succeed(await Repos.GetAllActive()));
        }
    }
}
