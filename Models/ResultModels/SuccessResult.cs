using System;
using System.Collections.Generic;
using System.Text;

namespace VPProject.Models.ResultModels
{
    public class SuccessResult : Result
    {
        public SuccessResult(object Root, string Message) : base(true, Root, Message, ResultCodeEnum.Success)
        {
        }
    }
    public enum ResultCodeEnum
    {
        Success,
        Failure
    }
}
