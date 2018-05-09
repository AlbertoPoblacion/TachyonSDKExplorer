using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SdkHarness.Models
{
    class ApiMethod
    {
        public MethodInfo MethodInfo { get; set; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(this.MethodInfo.Name);
            sb.Append(" ( ");

            ParameterInfo[] parameters = this.MethodInfo.GetParameters();
            if (parameters.Length > 0)
            {
                foreach (ParameterInfo parameter in parameters)
                {
                    sb.Append(parameter.Name);
                    sb.Append(", ");
                }

                sb.Remove(sb.Length - 2, 2);
            }

            sb.Append(" )");

            return sb.ToString();
        }
    }
}
