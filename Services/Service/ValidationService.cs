using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Models.UIModels;
using VPProject.Services.Interface;

namespace VPProject.Services.Service
{
    public class ValidationService : IValidationService
    {
        public bool CheckDates(BookInputModel inputModel)
        {
            if (inputModel.BookReturn.CompareTo(inputModel.BookCheckIn) >= 0)
            {
                return true;
            }
            return false;
        }

        public List<string> GetErrors(ModelStateDictionary.ValueEnumerable values)
        {
            List<string> modelError = new List<string>();
            foreach (var modelState in values)
            {
                foreach (ModelError error in modelState.Errors)
                {
                    modelError.Add(error.ErrorMessage);
                }
            }
            return modelError;
        }
    }
}
