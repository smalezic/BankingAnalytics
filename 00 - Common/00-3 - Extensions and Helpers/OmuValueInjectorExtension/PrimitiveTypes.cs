using System;
using System.Linq;

namespace Omu.ValueInjecter
{
    public class PrimitiveTypes : ConventionInjection
    {
        protected override bool Match(ConventionInfo c)
        {
            return c.SourceProp.Name == c.TargetProp.Name
                && (
                    c.SourceProp.Type == typeof(DateTime)
                    || c.SourceProp.Type == typeof(string)
                    || c.SourceProp.Type == typeof(Nullable<DateTime>)
                    || c.SourceProp.Type == typeof(Decimal)
                    || c.SourceProp.Type == typeof(Nullable<Decimal>)
                    || c.SourceProp.Type == typeof(long)
                    || c.SourceProp.Type.IsEnum
                    || c.SourceProp.Type.IsPrimitive
                    ||
                        (
                        c.SourceProp.Type.IsGenericType &&
                        c.SourceProp.Type.GetGenericTypeDefinition() == typeof(Nullable<>) &&
                        c.SourceProp.Type.GetGenericArguments().Any(t => t.IsValueType && (t.IsPrimitive || t.IsEnum))
                        )
                    )
                   && (c.SourceProp.Type == c.TargetProp.Type);
        }
    }
}
