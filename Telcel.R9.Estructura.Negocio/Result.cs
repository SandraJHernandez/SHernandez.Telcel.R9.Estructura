using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telcel.R9.Estructura.Negocio
{
    public class Result
    {
        public string Message { get; set; }
        public Exception Ex { get; set; }
        public Object Object { get; set; }
        public bool Correct { get; set; }
        public List<Object> Objects { get; set; }
    }
}
