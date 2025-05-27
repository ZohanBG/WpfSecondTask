using DiscountApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DiscountApp.ViewModels
{
    public class MainWindowVM : INotifyPropertyChanged
    {
        public ObservableCollection<Product> DiscountedProducts { get; set; }

        public string SearchQuery { get; set; }

        private Product _selectedProduct;
        public Product SelectedP
        {
            get => _selectedProduct;
            set
            {
                _selectedProduct = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(SelectedPFormattedDeadline));
            }
        }

        public MainWindowVM(IEnumerable<Product> products)
        {
            DiscountedProducts = new ObservableCollection<Product>(products);
            SelectedP = DiscountedProducts.FirstOrDefault();
        }

        public string SelectedPFormattedDeadline
        {
            get
            {
                if (SelectedP?.Disc == null)
                    return "Няма отстъпка";

                var remaining = SelectedP.Disc.ValidUntil - DateTime.Now;
                if (remaining.TotalSeconds <= 0)
                    return "Отстъпката е изтекла";

                return $"Остават {remaining.Days} дни {remaining.Hours} часа";
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
