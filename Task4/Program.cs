using System;
using System.Text;

namespace Task4
{
    // Версія А: Публічні поля без перевірок
    public class ProductA
    {
        public string Title;
        public decimal Price;
    }

    // Версія Б: Інкапсульований інтерфейс із валідацією
    public class ProductB
    {
        private string _title = "Без назви";
        private decimal _price;

        public string Title
        {
            get => _title;
            set => _title = !string.IsNullOrWhiteSpace(value) ? value : throw new ArgumentException("Назва не може бути порожньою!");
        }

        public decimal Price
        {
            get => _price;
            set => _price = value >= 0 ? value : throw new ArgumentException("Ціна не може бути від'ємною!");
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            // Версія А 
            Console.WriteLine("Публічні поля");
            var a = new ProductA { Title = "Ноутбук", Price = 25000 };
            Console.WriteLine($"Коректно: {a.Title}, {a.Price} грн");
            a.Title = "";        
            a.Price = -500;      
            Console.WriteLine($"Некоректно: '{a.Title}', {a.Price} грн (стан зламано)\n");

            // Версія Б 
            Console.WriteLine("Інкапсуляція");
            var b = new ProductB { Title = "Ноутбук", Price = 25000 };
            Console.WriteLine($"Коректно: {b.Title}, {b.Price} грн");
            
            try { b.Title = ""; }
            catch (Exception ex) { Console.WriteLine($"Помилка назви: {ex.Message}"); }

            try { b.Price = -500; }
            catch (Exception ex) { Console.WriteLine($"Помилка ціни: {ex.Message}"); }

            Console.WriteLine($"Фінальний стан Б: {b.Title}, {b.Price} грн (стан збережено)");
        }
    }
}