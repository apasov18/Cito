using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cito.Fabrics
{
    internal class _FabricContainer
    {
        protected static Dictionary<Type, Action<object>> Container { get; set; }

    }
}
