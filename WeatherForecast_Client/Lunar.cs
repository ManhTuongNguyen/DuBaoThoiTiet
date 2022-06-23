using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast_Client
{
    public class Lunar
    {
        List<string> Thu = new List<string>()
        {
            "Chủ nhật",
            "Thứ hai",
            "Thứ ba",
            "Thứ tư",
            "Thứ năm",
            "Thứ sáu",
            "Thứ bảy"
        };
        enum Chi { Tý, Sửu, Dần, Mão, Thìn, Tỵ, Ngọ, Mùi, Thân, Dậu, Tuất, Hợi }
        enum Can { Giáp, Ất, Bính, Đinh, Mậu, Kỷ, Canh, Tân, Nhâm, Quý }
        /// <summary>
        /// Tìm tên gọi Thứ của ngày hiện tại
        /// </summary>
        /// <returns>Tên gọi thứ của ngày hiện tại</returns>
        public string GetThu()
        {
            return Thu[(int)DateTime.Now.DayOfWeek];
        }
        /// <summary>
        /// Tìm tên gọi Chi của năm (12 chi)
        /// </summary>
        /// <param name="yy"></param>
        /// <returns></returns>
        public string GetChiNam(int yy)
        {
            return ((Chi)((yy + 8) % 12)).ToString();
        }
        /// <summary>
        /// Tìm tên gọi Can của năm (10 can)
        /// </summary>
        /// <param name="yy"></param>
        /// <returns></returns>
        public string GetCanNam(int yy)
        {
            return ((Can)((yy + 6) % 10)).ToString();
        }
        /// <summary>
        /// Tìm tên gọi Can của ngày
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="mm"></param>
        /// <param name="yy"></param>
        /// <returns></returns>
        private string getCanNgay(int dd, int mm, int yy)
        {
            long jd = jdFromDate(dd, mm, yy);
            return ((Can)((jd + 9) % 10)).ToString();
        }

        public string GetCanChiOfDay(int dd, int mm, int yy)
        {
            return getCanNgay(dd, mm, yy) + " " + getChiNgay(dd, mm, yy);
        }

        public string GetCanChiOfYear(int yy)
        {
            return GetCanNam(yy) + " " + GetChiNam(yy);
        }

        public string GetCanChiOfMoth(int mm, int yy)
        {
            return getCanThang(mm, yy) + " " + getChiThang(mm);
        }

        /// <summary>
        /// Tìm tên gọi Chi của ngày
        /// </summary>
        /// <param name="dd"></param>
        /// <param name="mm"></param>
        /// <param name="yy"></param>
        /// <returns></returns>
        private string getChiNgay(int dd, int mm, int yy)
        {
            long jd = jdFromDate(dd, mm, yy);
            return ((Chi)((jd + 1) % 12)).ToString();
        }
        /// <summary>
        /// Tìm tên gọi Chi của tháng (!tháng Âm Lịch)
        /// </summary>
        /// <param name="mm">Tháng âm lịch</param>
        /// <returns></returns>
        public string getChiThang(int mm) // mm la thang Am lich duoc tinh truoc do
        {
            int tam = (mm + 1) % 12; // Thang 11 la thang Ty, thang 12 la thang Suu
            return ((Chi)(tam)).ToString();
        }
        /// <summary>
        /// Tìm tên gọi Can của tháng, năm (!tháng Âm lịch, năm Âm lịch)
        /// </summary>
        /// <param name="mm">Tháng âm lịch</param>
        /// <param name="yy">Năm âm lịch</param>
        /// <returns></returns>
        public string getCanThang(int mm, int yy) // mm la thang am lich, yy nam am lich
        {
            int tam = (yy * 12 + mm + 3) % 10;
            return ((Can)(tam)).ToString();
        }
        public long jdFromDate(int dd, int mm, int yy)
        {
            var a = (int)(14 - mm) / 12;
            var y = yy + 4800 - a;
            var m = mm + 12 * a - 3;
            var jd = dd
                + (int)((153 * m + 2) / 5.0f)
                + (365 * y)
                + (int)(y / 4.0f) - (int)(y / 100.0f) + (int)(y / 400.0f) - 32045;
            if (jd < 2299161)
            {
                jd = dd + (int)((153 * m + 2) / 5.0f) + 365 * y + (int)(y / 4.0f) - 32083;
            }
            return jd;
        }

        // Tinh ngay Soc
        public int GetNewMoonDay(int k, int timeZone)
        {
            // T, T2, T3, dr, Jd1, M, Mpr, F, C1, deltat, JdNew;
            var T = k / 1236.85f; // Time in Julian centuries from 1900 January 0.5
            var T2 = T * T;
            var T3 = T2 * T;
            var dr = Math.PI / 180.0f;
            var Jd1 = 2415020.75933 + 29.53058868 * k + 0.0001178 * T2 - 0.000000155 * T3;
            Jd1 = Jd1 + 0.00033 * Math.Sin((166.56 + 132.87 * T - 0.009173 * T2) * dr); // Mean new moon
            var M = 359.2242 + 29.10535608 * k - 0.0000333 * T2 - 0.00000347 * T3; // Sun's mean anomaly
            var Mpr = 306.0253 + 385.81691806 * k + 0.0107306 * T2 + 0.00001236 * T3; // Moon's mean anomaly
            var F = 21.2964 + 390.67050646 * k - 0.0016528 * T2 - 0.00000239 * T3; // Moon's argument of latitude
            var C1 = (0.1734 - 0.000393 * T) * Math.Sin(M * dr) + 0.0021 * Math.Sin(2 * dr * M);
            C1 = C1 - 0.4068 * Math.Sin(Mpr * dr) + 0.0161 * Math.Sin(dr * 2 * Mpr);
            C1 = C1 - 0.0004 * Math.Sin(dr * 3 * Mpr);
            C1 = C1 + 0.0104 * Math.Sin(dr * 2 * F) - 0.0051 * Math.Sin(dr * (M + Mpr));
            C1 = C1 - 0.0074 * Math.Sin(dr * (M - Mpr)) + 0.0004 * Math.Sin(dr * (2 * F + M));
            C1 = C1 - 0.0004 * Math.Sin(dr * (2 * F - M)) - 0.0006 * Math.Sin(dr * (2 * F + Mpr));
            C1 = C1 + 0.0010 * Math.Sin(dr * (2 * F - Mpr)) + 0.0005 * Math.Sin(dr * (2 * Mpr + M));
            double deltat;
            if (T < -11)
            {
                deltat = 0.001 + 0.000839 * T + 0.0002261 * T2 - 0.00000845 * T3 - 0.000000081 * T * T3;
            }
            else
            {
                deltat = -0.000278 + 0.000265 * T + 0.000262 * T2;
            };
            var JdNew = Jd1 + C1 - deltat;
            return (int)(JdNew + 0.5 + timeZone / 24.0f);
        }

        // Trung khi
        public int GetSunLongitude(double jdn, int timeZone)
        {
            //double T, T2, dr, M, L0, DL, L;
            var T = (jdn - 2451545.5 - timeZone / 24) / 36525; // Time in Julian centuries from 2000-01-01 12:00:00 GMT
            var T2 = T * T;
            var dr = Math.PI / 180; // degree to radian
            var M = 357.52910 + 35999.05030 * T - 0.0001559 * T2 - 0.00000048 * T * T2; // mean anomaly, degree
            var L0 = 280.46645 + 36000.76983 * T + 0.0003032 * T2; // mean longitude, degree
            var DL = (1.914600 - 0.004817 * T - 0.000014 * T2) * Math.Sin(dr * M);
            DL = DL + (0.019993 - 0.000101 * T) * Math.Sin(dr * 2 * M) + 0.000290 * Math.Sin(dr * 3 * M);
            var L = L0 + DL; // true longitude, degree
            L = L * dr;
            L = L - Math.PI * 2 * ((int)(L / (Math.PI * 2))); // Normalize to (0, 2*PI)
            return (int)(L / Math.PI * 6);
        }

        // Tim ngay bat dau thang 11 am lich
        public int GetLunarMonth11(int yy, int timeZone)
        {
            var off = jdFromDate(31, 12, yy) - 2415021;  // truoc 31/12/yy
            var k = (int)(off / 29.530588853);
            var nm = GetNewMoonDay(k, timeZone); // tim ngay soc truoc 31/12/yy
            var sunLong = GetSunLongitude(nm, timeZone); // sun longitude at local midnight
            if (sunLong >= 9) // Neu thang bat dau vau ngay soc do khong co dong chi, 
            {
                nm = GetNewMoonDay(k - 1, timeZone); // thi lui 1 thang va tinh lai ngay soc
            }
            return nm;
        }

        // Xac dinh thang nhuan
        public int GetLeapMonthOffset(long a11, int timeZone)
        {
            int k, last, arc, i;
            k = (int)((a11 - 2415021.076998695) / 29.530588853 + 0.5);
            i = 1; // We start with the month following lunar month 11
            arc = GetSunLongitude(GetNewMoonDay(k + i, timeZone), timeZone);
            do
            {
                last = arc;
                i++;
                arc = GetSunLongitude(GetNewMoonDay(k + i, timeZone), timeZone);
            } while (arc != last && i < 14);
            return i - 1;
        }

        // Duong lich sang Am lich 
        public int[] ConvertSolar2Lunar(int dd, int mm, int yy, int timeZone = 7)
        {
            var dayNumber = jdFromDate(dd, mm, yy);
            var k = (int)((dayNumber - 2415021.076998695) / 29.530588853);
            var monthStart = GetNewMoonDay(k + 1, timeZone);
            if (monthStart > dayNumber)
            {
                monthStart = GetNewMoonDay(k, timeZone);
            }
            var a11 = GetLunarMonth11(yy, timeZone);
            var b11 = a11;

            int lunarYear;
            if (a11 >= monthStart)
            {
                lunarYear = yy;
                a11 = GetLunarMonth11(yy - 1, timeZone);
            }
            else
            {
                lunarYear = yy + 1;
                b11 = GetLunarMonth11(yy + 1, timeZone);
            }
            var lunarDay = (int)(dayNumber - monthStart + 1);
            var diff = (int)((monthStart - a11) / 29);
            var lunarMonth = diff + 11;
            if (b11 - a11 > 365)
            {
                var leapMonthDiff = GetLeapMonthOffset(a11, timeZone);
                if (diff >= leapMonthDiff)
                {
                    lunarMonth = diff + 10;
                }
            }
            if (lunarMonth > 12)
            {
                lunarMonth = lunarMonth - 12;
            }
            if (lunarMonth >= 11 && diff < 4)
            {
                lunarYear -= 1;
            }
            return new int[] { lunarDay, lunarMonth, lunarYear };
        }
    }
}
