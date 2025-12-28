using System.Text.RegularExpressions;


namespace Common.Domain.Exeptions
{
    public static class  IranianNationalIdChecker
    {
        public static bool IsValidNatinalCode(this string nationalId)
        {
            if (string.IsNullOrWhiteSpace(nationalId))
                return false;

            // بررسی اینکه فقط عدد باشد
            var isNumber = Regex.IsMatch(nationalId, @"^\d+$");
            if (isNumber == false)
                return false;

            var code = nationalId;

            // بررسی طول کد ملی (باید 10 رقم باشد)
            if (!Regex.IsMatch(code, @"^\d{10}$"))
                return false;

            // بررسی اینکه 6 رقم میانی صفر نباشد
            if (Convert.ToInt32(code.Substring(3, 6), 10) == 0)
                return false;

            var lastNumber = Convert.ToInt32(code.Substring(9, 1), 10);
            var sum = 0;

            // محاسبه مجموع وزنی
            for (var i = 0; i < 9; i++)
            {
                sum += Convert.ToInt32(code.Substring(i, 1), 10) * (10 - i);
            }

            sum = sum % 11;

            // بررسی کنترل رقم
            return sum < 2 && lastNumber == sum || sum >= 2 && lastNumber == 11 - sum;
        }
    }

}
