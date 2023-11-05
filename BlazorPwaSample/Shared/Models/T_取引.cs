using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorPwaSample.Shared.Models
{
    public class T_取引
    {
        public int Id { get; set; }
        public string? 取引会社 { get; set; }
        public string? 銘柄 { get; set; }
        public DateTime 日付 { get; set; }
        public int? 数量 { get; set; }
        public int? 建値 { get; set; }
        public int? 決済値 { get; set; }
        public int 損益 { get; set; }
        public DateTime? 更新日時 { get; set; }

        /// <summary>
        /// 値比較
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
                return false;

            var aaa = 更新日時?.ToString("yyyy-MM-dd HH:mm:ss");

            T_取引 other = (T_取引)obj;
            return (取引会社 == other.取引会社) &&
                   (銘柄 == other.銘柄) &&
                   (日付 == other.日付) &&
                   (数量 == other.数量) &&
                   (建値 == other.建値) &&
                   (決済値 == other.決済値) &&
                   (損益 == other.損益) &&
                   (更新日時?.ToString("yyyy-MM-dd HH:mm:ss") == other.更新日時?.ToString("yyyy-MM-dd HH:mm:ss"));
        }
    }
}
