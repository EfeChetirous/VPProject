using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VPProject.Constants;
using VPProject.Data.Repository;
using VPProject.Models.Entities;
using VPProject.Models.ResultModels;
using VPProject.Models.UIModels;
using VPProject.Services.Interface;

namespace VPProject.Services.Service
{
    public class PenaltyService : IPenaltyService
    {
        private readonly IRepository<Country> _countryRepository;
        public PenaltyService(IRepository<Country> countryRepository)
        {
            _countryRepository = countryRepository;
        }
        public Result CalculatePenaltyAmount(BookInputModel inputModel)
        {
            var countryWithSetting = _countryRepository.Queryable().Include(x => x.CountrySetting).Include(x=>x.CountryHolidays).FirstOrDefault(x => x.Id == inputModel.CountryId);
            int daysWithoutHolidays = findTotalDaysWithoutHolidays(countryWithSetting, inputModel);

            if (daysWithoutHolidays > VPConstants.BookLoanDay)
            {
                //calculate the penalty fee.
                decimal totalPenaltyAmount =  (daysWithoutHolidays - VPConstants.BookLoanDay) * countryWithSetting.CountrySetting.PenaltyAmount;
                return new SuccessResult(totalPenaltyAmount, $"{VPConstants.TotalPenaltyFee} {totalPenaltyAmount}");
            }
            return new SuccessResult(0,VPConstants.NoPenaltyFee);
        }

        /// <summary>
        /// finding total days without special days and weekends
        /// </summary>
        /// <param name="bookLoanDay"></param>
        /// <param name="country"></param>
        /// <param name="inputModel"></param>
        /// <returns></returns>
        private int findTotalDaysWithoutHolidays(Country country, BookInputModel inputModel)
        {
            int totalBookLoanDay = 0;
            for (var date = inputModel.BookCheckIn; date <= inputModel.BookReturn; date = date.AddDays(1))
            {
                //checking holidays and weekends
                if (country.CountryHolidays.Any(x => x.HolidayDate == date)
                        || date.DayOfWeek.ToString() == country?.CountrySetting?.OffDayFirst || date.DayOfWeek.ToString() == country?.CountrySetting?.OffDaySecond 
                        || date.DayOfWeek.ToString() == country?.CountrySetting?.OffDayThird)
                {
                    continue;
                }
                totalBookLoanDay++;
            }
            return totalBookLoanDay;
        }
    }
}
