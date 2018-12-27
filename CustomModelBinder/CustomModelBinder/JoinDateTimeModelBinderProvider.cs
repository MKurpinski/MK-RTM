using System;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CustomModelBinder
{
    public class JoinDateTimeModelBinderProvider: IModelBinderProvider
    {
        public IModelBinder GetBinder(ModelBinderProviderContext context)
        {
            var binder = new JoinDateTimeModelBinder(new SimpleTypeModelBinder(typeof(DateTime)));

            return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
        }
    }
}
