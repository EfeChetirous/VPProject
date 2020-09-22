using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Models.UIModels;
using static Microsoft.AspNetCore.Mvc.ModelBinding.ModelStateDictionary;

namespace VPProject.Services.Interface
{
    public interface IValidationService
    {
        List<string> GetErrors(ValueEnumerable values);
        bool CheckDates(BookInputModel inputModel);
    }
}
