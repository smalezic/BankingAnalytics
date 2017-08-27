using Omu.ValueInjecter.Injections;
using Omu.ValueInjecter.Utils;
using System;

namespace Omu.ValueInjecter
{
    public abstract class ConventionInjection : ValueInjection
    {
        protected abstract bool Match(ConventionInfo c);

        protected virtual object SetValue(ConventionInfo c)
        {
            return c.SourceProp.Value;
        }

        protected override void Inject(object source, object target)
        {
            var sourceProps = source.GetProps();
            var targetProps = target.GetProps();

            var ci = new ConventionInfo
            {
                Source = { Type = source.GetType(), Value = source },
                Target = { Type = target.GetType(), Value = target }
            };

            for (var i = 0; i < sourceProps.Length; i++)
            {
                var sourceProp = sourceProps[i];
                if (sourceProp.CanRead)
                {
                    ci.SourceProp.Name = sourceProp.Name;
                    ci.SourceProp.Type = sourceProp.PropertyType;

                    for (var j = 0; j < targetProps.Length; j++)
                    {
                        var targetProp = targetProps[j];

                        ci.TargetProp.Name = targetProp.Name;
                        ci.TargetProp.Type = targetProp.PropertyType;

                        if (Match(ci) && targetProp.CanWrite)
                        {
                            ci.SourceProp.Value = sourceProp.GetValue(source);
                            if (ci.SourceProp.Value != null)
                            {
                                ci.TargetProp.Value = targetProp.GetValue(target);
                                if (ci.TargetProp.Value != null)
                                {
                                    if (ci.SourceProp.Value.Equals(ci.TargetProp.Value))
                                    {
                                        break;
                                    }
                                }
                            }
                            targetProp.SetValue(target, SetValue(ci));
                            break;
                        }
                    }
                }
            }
        }
    }
}
