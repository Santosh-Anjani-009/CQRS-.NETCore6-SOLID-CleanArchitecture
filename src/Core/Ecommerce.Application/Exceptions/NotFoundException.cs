using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException(string name, Object key) : base($"{name}-{key} not found")
        {
        }
    }
}
