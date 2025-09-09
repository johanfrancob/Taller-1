using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Shared.Responses
{
    public class ActionResponse<T>
    {
        public bool WasSuccess { get; set; } // devuelve true o false de la acción

        public string? Message { get; set; }

        public T? Result { get; set; }
    }
}
