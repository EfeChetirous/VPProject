using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Constants;
using VPProject.Data.Repository;
using VPProject.Models.Entities;
using VPProject.Models.ResultModels;
using VPProject.Services.Interface;

namespace VPProject.Services.Service
{
    public class CountryService : ICountryService
    {
        private readonly IRepository<Country> _countryRepository;
        public CountryService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Result GetAll()
        {
            try
            {
                var countryList = _countryRepository.GetAll().Where(x => x.SoftDelete == false).ToList();
                return new SuccessResult(countryList, VPConstants.CountriesList);
            }
            catch (Exception ex)
            {
                return new FailureResult();
            }            
        }
    }
}
