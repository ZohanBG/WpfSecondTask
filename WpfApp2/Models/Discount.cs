using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscountApp.Models
{
    public class Discount
    {
        public int DiscountId { get; set; }
        public int ProductId { get; set; }
        public float DiscountPerc { get; set; }

        private DateTime _validUntil;

        // 🔧 This is still DateTime, so binding stays valid
        public DateTime ValidUntil
        {
            get => _validUntil;
            set => _validUntil = value;
        }

        // 🔁 This override changes how it appears in XAML
        public override string ToString()
        {
            var remaining = _validUntil - DateTime.Now;
            if (remaining.TotalSeconds <= 0)
                return "Отстъпката е изтекла";

            return $"Остават {remaining.Days} дни {remaining.Hours} часа";
        }
    }
}