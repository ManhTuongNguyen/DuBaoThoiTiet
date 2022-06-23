using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast_Client
{
    public class WeatherForecastClientHelper
    {
        /// <summary>
        /// Danh sách 63 tỉnh thành của nước Việt Nam
        /// </summary>
        /// Source: https://visadep.vn/danh-sach-63-tinh-thanh-viet-nam.html
        public static List<string> SixtyThreeCityInVietNam = new List<string>
        {
            "An Giang",
            "Bà rịa – Vũng tàu",
            "Bắc Giang",
            "Bắc Kạn",
            "Bạc Liêu",
            "Bắc Ninh",
            "Bến Tre",
            "Bình Định",
            "Bình Dương",
            "Bình Phước",
            "Bình Thuận",
            "Cà Mau",
            "Cần Thơ",
            "Cao Bằng",
            "Đà Nẵng",
            "Đắk Lắk",
            "Đắk Nông",
            "Điện Biên",
            "Đồng Nai",
            "Đồng Tháp",
            "Gia Lai",
            "Hà Giang",
            "Hà Nam",
            "Hà Nội",
            "Hà Tĩnh",
            "Hải Dương",
            "Hải Phòng",
            "Hậu Giang",
            "Hòa Bình",
            "Hưng Yên",
            "Khánh Hòa",
            "Kiên Giang",
            "Kon Tum",
            "Lai Châu",
            "Lâm Đồng",
            "Lạng Sơn",
            "Lào Cai",
            "Long An",
            "Nam Định",
            "Nghệ An",
            "Ninh Bình",
            "Ninh Thuận",
            "Phú Thọ",
            "Phú Yên",
            "Quảng Bình",
            "Quảng Nam",
            "Quảng Ngãi",
            "Quảng Ninh",
            "Quảng Trị",
            "Sóc Trăng",
            "Sơn La",
            "Tây Ninh",
            "Thái Bình",
            "Thái Nguyên",
            "Thanh Hóa",
            "Thừa Thiên Huế",
            "Tiền Giang",
            "Thành phố Hồ Chí Minh",
            "Trà Vinh",
            "Tuyên Quang",
            "Vĩnh Long",
            "Vĩnh Phúc",
            "Yên Bái"
        };

        private static readonly string[] VietnameseSigns = new string[]
        {

            "aAeEoOuUiIdDyY",
            "áàạảãâấầậẩẫăắằặẳẵ",
            "ÁÀẠẢÃÂẤẦẬẨẪĂẮẰẶẲẴ",
            "éèẹẻẽêếềệểễ",
            "ÉÈẸẺẼÊẾỀỆỂỄ",
            "óòọỏõôốồộổỗơớờợởỡ",
            "ÓÒỌỎÕÔỐỒỘỔỖƠỚỜỢỞỠ",
            "úùụủũưứừựửữ",
            "ÚÙỤỦŨƯỨỪỰỬỮ",
            "íìịỉĩ",
            "ÍÌỊỈĨ",
            "đ",
            "Đ",
            "ýỳỵỷỹ",
            "ÝỲỴỶỸ"
        };

        public static string GetCityNameRemovedSign(string cityName)
        {
            //Do API cung cấp thông tin địa chỉ của một vài khu vực không chính xác
            // => Thay thế tên tỉnh bằng tên thành phố / huyện thuộc tỉnh đó để có thông tin chính xác hơn
            switch (cityName)
            {
                case "Bà rịa – Vũng tàu":
                    return "Vung Tau";
                case "Đắk Lắk":
                    return "Buon Ma Thuot";
                case "Đắk Nông":
                    return "Gia Nghia";
                case "Nghệ An":
                    return "Dien Chau";
                case "Bình Dương":
                    return "Thu Dau Mot";
                case "Hưng Yên":
                    return "My Hao";
                case "Phú Yên":
                    return "Tuy Hoa";
                case "Hậu Giang":
                    return "Vi Thanh";
                case "Tiền Giang":
                    return "Cho Gao";
                case "Quảng Ninh":
                    return "Cam Pha";
                case "Quảng Bình":
                    return "Tuyen Hoa";
                case "Kiên Giang":
                    return "Kien Luong";
                case "Lâm Đồng":
                    return "Da Lat";
                case "Long An":
                    return "Duc Hue";
                case "Ninh Thuận":
                    return "Phan Rang - Thap Cham";
                case "Phú Thọ":
                    return "Viet Tri";
                case "Bình Thuận":
                    return "Phan Ly Cham";
                case "Bình Phước":
                    return "Dong Xoai";
                case "Đà Nẵng":
                    return "Hai Chau";
                case "Đồng Nai":
                    return "Bien Hoa";
                case "Đồng Tháp":
                    return "Cao Lanh";
                case "Hà Nam":
                    return "Phu Ly";
                case "Khánh Hòa":
                    return "Nha Trang";

                default:
                    return RemoveSignForVietnameseString(cityName);
            }
        }

        /// <summary>
        /// Phương thức loại bỏ dấu trong các chuỗi tiếng việt
        /// </summary>
        /// <param name="str">Chuỗi kí tự có chứa dấu</param>
        /// <returns>Chuỗi kí tự đã được loại bỏ dấu</returns>
        public static string RemoveSignForVietnameseString(string str)
        {
            for (int i = 1; i < VietnameseSigns.Length; i++)
            {
                for (int j = 0; j < VietnameseSigns[i].Length; j++)
                    str = str.Replace(VietnameseSigns[i][j], VietnameseSigns[0][i - 1]);
            }
            return str;
        }

        /// <summary>
        /// Thông tin sự nguy hiểm của tia UV đối với sức khỏe
        /// </summary>
        /// Source: https://collagenmidi.com/kien-thuc-lam-dep/chi-so-tia-uv-bao-nhieu-la-co-hai-co-suc-khoe--51.html
        public static Dictionary<int, string> DangerousInfoOfUV = new Dictionary<int, string>()
        {
            [1] = "Chỉ số này cho thấy lượng bức xạ mặt trời trong ngày rất thấp. Bạn " +
            "sẽ ít bị ảnh hưởng bởi các tác hại của tia uv hơn. Hầu hết mọi người có thể ở " +
            "dưới ánh nắng mặt trời khoảng 1 giờ trong thời gian cao điểm (từ 10h sáng đến " +
            "16h chiều) mà không bị cháy nắng.",
            [2] = "Lúc này lượng bức xạ uv đang ở mức trung bình. Các vấn đề về tia uv đối với da sẽ " +
            "nghiêm trọng hơn một chút nhưng vẫn nằm trong ngưỡng cho phép. Những người có làn da nhạy" +
            " cảm dễ bị cháy nắng trong vòng 20 phút. Đội mũ có vành rộng và kính râm để bảo vệ mắt. Luôn" +
            " sử dụng kem chống nắng có chỉ số SPF ít nhất là 30 và mặc áo dài tay khi đi ra ngoài.",
            [3] = "Chỉ số này cho thấy lượng bức xạ mặt trời khá cao. Bạn nên cẩn thận hơn mỗi khi ra đường. " +
            "Đội mũ rộng vành và kính râm để bảo vệ mắt, mũi và vành tai. Bạn cũng nên bôi kem chống nắng có " +
            "chỉ số SPF ít nhất là 30, mặc quần áo dài.",
            [4] = "Những ngày hè thường có lượng tia uv rất cao, từ 8-10. Nếu bạn không cẩn thận, khả năng " +
            "bạn bị cháy nắng là rất cao. Người có làn da nhạy cảm có thể bị bỏng trong vòng chưa đầy 10 phút. " +
            "Giảm thiểu phơi nắng từ 10h đến 16h. Bôi kem chống nắng có chỉ số SPF ít nhất là 30. Nên đeo kính " +
            "râm, mặc quần áo dài với chất liệu dày dặn khi ra ngoài trời.",
            [5] = "Mức độ uv trong ngày đáng báo động. Bạn có thể bị bỏng chỉ trong vòng 5 phút khi không bảo " +
            "vệ. Tốt nhất bạn nên ở trong nhà và đóng cửa lại thay vì ra đường vào thời điểm này."
        };

        /// <summary>
        /// Convert byte recieve from Server to DataTable
        /// </summary>
        /// <param name="data">Data recieve from Server</param>
        /// <returns>DataTable info of weather</returns>
        public static T FromByteArray<T>(byte[] data)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            try
            {
                using (MemoryStream memoryStream = new MemoryStream(data))
                {
                    object obj = binaryFormatter.Deserialize(memoryStream);
                    return (T)obj;
                }
            }
            catch (Exception)
            {
                return default(T);
            }
        }

        public static Bitmap GetWeatherIconFromBytes(byte[] data)
        {
            MemoryStream memoryStream = new MemoryStream(data);
            return new Bitmap(memoryStream);
        }
    }
}
