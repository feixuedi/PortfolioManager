using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioManager.Models
{
    public class ResponseResult<T>
    {
        public string Status { get; set; }
        public T Data { get; set; }
        public ResponseResult()
        {
            Status = "success";
        }
    }
}
