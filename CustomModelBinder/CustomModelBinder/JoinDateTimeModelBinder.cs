using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CustomModelBinder
{
    public class JoinDateTimeModelBinder : IModelBinder
    {
        private readonly IModelBinder _fallbackModelBinder;

        public JoinDateTimeModelBinder(IModelBinder fallbackModelBinder)
        {
            _fallbackModelBinder = fallbackModelBinder;
        }

        public Task BindModelAsync(ModelBindingContext bindingContext)
        {
            var dateValues = GetPartValues(bindingContext, "DatePart");
            var timeValues = GetPartValues(bindingContext, "TimePart");

            if (!dateValues.Any()|| !timeValues.Any())
            {
                return _fallbackModelBinder.BindModelAsync(bindingContext);
            }

            var parseDateResult = DateTime.TryParse(dateValues.FirstValue, out var parsedDatePart);
            var parseTimeResult = DateTime.TryParse(timeValues.FirstValue, out var parsedTimePart);
                
            if (!parseTimeResult || !parseDateResult)
            {
                return _fallbackModelBinder.BindModelAsync(bindingContext);
            }

            var result = new DateTime(parsedDatePart.Year, parsedDatePart.Month, parsedDatePart.Day, parsedTimePart.Hour, parsedTimePart.Minute, parsedTimePart.Second);

            bindingContext.ModelState.SetModelValue(bindingContext.ModelName, result, $"{dateValues.FirstValue} {timeValues.FirstValue}");
            bindingContext.Result = ModelBindingResult.Success(result);

            return Task.CompletedTask;
        }

        private ValueProviderResult GetPartValues(ModelBindingContext bindingContext, string valueSuffix)
        {
            return bindingContext.ValueProvider.GetValue($"{bindingContext.ModelName}.{valueSuffix}");
        }
    }
}
