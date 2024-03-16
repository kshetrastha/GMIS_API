using System.Globalization;

namespace gmis.Shared.Extensions
{
    public static class DateTimeExtension
    {
        /// <summary>
        /// Return datetime as string in dd/M/yyyy format
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
        public static string DateOnlyFormat(this DateTime dateTimeValue)
        {
            return dateTimeValue.ToString("dd/M/yyyy", CultureInfo.InvariantCulture); ;
        }

        /// <summary>
        /// Return datetime as string in yyyy-MM-dd format
        /// </summary>
        /// <param name="dateTimeValue"></param>
        /// <returns></returns>
        public static string YearFirstDateOnly(this DateTime dateTimeValue)
        {
            return dateTimeValue.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture); ;
        }

    }
}
