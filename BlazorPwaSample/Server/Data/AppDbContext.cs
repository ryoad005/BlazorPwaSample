using BlazorPwaSample.Shared.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace BlazorPwaSample.Server.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<T_取引> T_取引 { get; set; }

        public DbSet<T_FX会社> T_FX会社 { get; set; }

        public DbSet<T_銘柄> T_銘柄 { get; set; }

        public List<SelectListItem> GetFX会社リスト()
        {
            if (this.T_FX会社 == null)
            {
                return null;
            }

            var fxCompanies = this.T_FX会社.ToList();

            // T_FX会社のリストをSelectListItemのリストに変換する
            var list = fxCompanies.Select(f => new SelectListItem
            {
                Value = f.会社コード, // 会社コードをvalue属性に設定する
                Text = f.会社名 // 会社名をテキストに設定する
            }).ToList();

            // ViewBagにSelectListItemのリストを渡す
            return list;
        }

        public List<SelectListItem> Get銘柄リスト()
        {
            if (this.T_銘柄 == null)
            {
                return null;
            }

            var brands = this.T_銘柄.ToList();

            var list = brands.Select(f => new SelectListItem
            {
                Value = f.銘柄コード,
                Text = f.銘柄名
            }).ToList();

            return list;
        }
    }
}
