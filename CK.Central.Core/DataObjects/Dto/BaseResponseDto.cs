using CK.Central.Core.DataObjects.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.DataObjects.Dto
{
    public abstract class BaseResponseDto : BaseEntity
    {
        /// <summary>
        /// 
        /// </summary>
        public static object Succeed(object? data = null) => new { Succeeded = true, Data = data };

        /// <summary>
        /// 
        /// </summary>
        /// <param name="error"></param>
        /// <returns></returns>
        public static object Fail(string error) => new { Succeeded = false, Error = error };
    }
}
