using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Application.Common
{
    public class ValidationMessages
    {
        public const string RecaptchaError = "اعتبار سنجی Recaptcha انجام نشد";
        public const string Required = "این فیلد اجباری می‌باشد";

        public static string RequiredField(string field) => $"{field} اجباری می‌باشد";
        public static string MaxLength(string field, int maxLength) => $"{field} باید کمتر از {maxLength} کاراکتر باشد";
        public static string MinLength(string field, int minLength) => $"{field} باید بیشتر از {minLength} کاراکتر باشد";
    }
}
