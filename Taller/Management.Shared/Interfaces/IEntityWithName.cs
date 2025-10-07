using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Management.Shared.Interfaces
{
    public interface IEntityWithName
    {
        string FirstName { get; set; }
        string LastName { get; set; }

    }
}
