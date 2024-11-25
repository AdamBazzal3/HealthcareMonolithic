using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Healthcare.Module.Attributes
{

    [AttributeUsage(AttributeTargets.Property)]
    public class IgnoreConvertToJsonAttribute : Attribute { }
}
