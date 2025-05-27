using System.Linq;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using DiscountApp.Models;
using DiscountApp.ViewModels;

namespace DiscountApp.Views
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            using var context = new ProductsContext();

            context.Database.EnsureCreated();

            if (!context.Products.Include(p => p.Disc).Any())
            {
                context.Products.AddRange(new[] {
                new Product {
                    Name = "Бисквити",
                    Type = "Храна",
                    RegularPrice = 2.99m,
                    Disc = new Discount { DiscountPerc = 10, ValidUntil = DateTime.Now.AddDays(2) }
                },
                new Product {
                    Name = "Шоколад",
                    Type = "Храна",
                    RegularPrice = 3.49m,
                    Disc = new Discount { DiscountPerc = 15, ValidUntil = DateTime.Now.AddHours(12) }
                },
                new Product {
                    Name = "Кифли",
                    Type = "Храна",
                    RegularPrice = 3.49m,
                    Disc = new Discount { DiscountPerc = 15, ValidUntil = DateTime.Now.AddHours(12) }
                },
                new Product {
                    Name = "Портокали",
                    Type = "Храна",
                    RegularPrice = 3.49m,
                    Disc = new Discount { DiscountPerc = 15, ValidUntil = DateTime.Now.AddHours(12) }
                },
                new Product {
                    Name = "Банани",
                    Type = "Храна",
                    RegularPrice = 3.49m,
                    Disc = new Discount { DiscountPerc = 15, ValidUntil = DateTime.Now.AddHours(12) }
                }

            });
                context.SaveChanges();
            }

            var products = context.Products.Include(p => p.Disc).ToList();
            DataContext = new MainWindowVM(products);
        }
    }
}
