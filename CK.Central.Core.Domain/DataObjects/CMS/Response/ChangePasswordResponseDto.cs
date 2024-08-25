using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CK.Central.Core.Domain.DataObjects.CMS.Response
{
    public class ChangePasswordResponseDto<T>
    {
        public ChangePasswordResponseDto() { }

        public bool? Success { get; set; }
        public string? Message { get; set; }
        public T? Data { get; set; }
    }
}
