using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Models.ResultModels;
using VPProject.Models.UIModels;

namespace VPProject.Services.Interface
{
    public interface IPenaltyService
    {
        Result CalculatePenaltyAmount(BookInputModel inputModel);
    }
}
