using System;
using System.Linq;

namespace Omu.ValueInjecter
{
    public class PrimitiveTypesExcludeId : PrimitiveTypes
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name != "Id"    // Do NOT synchronize Id field !!!
                && base.Match(c);
        }
    }
}
