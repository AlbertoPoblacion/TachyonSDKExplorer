using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SdkHarness.Models
{
    class ApiType
    {
        public Type Type { get; set; }

        public override string ToString()
        {
            return this.Type.Name;
        }
    }
}
