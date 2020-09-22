using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Models.Entities;
using VPProject.Models.ResultModels;

namespace VPProject.Services.Interface
{
    public interface ICountryService
    {
        Result GetAll();
    }
}
