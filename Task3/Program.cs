using System;
using System.Text;

namespace Task3
{
    public class UserProfile
    {
        // 1. Атрибут, що змінюється протягом життя об'єкта (відкритий get і set)
        public string StatusMessage { get; set; }

        // 2. Встановлюється при створенні, ззовні лише читається (private set)
        public int Id { get; private set; }

        // 3. Init-only властивість: задається лише при конструюванні / ініціалізаторі
        public string TaxNumber { get; init; }

        // Допоміжні властивості для демонстрації обчислюваної
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // 4. Повністю обчислювана властивість без власного сховища (backing field)
        public string FullName => $"{FirstName} {LastName}";

        // Конструктор для демонстрації встановлення Id
        public UserProfile(int id, string taxNumber)
        {
            Id = id;             
            TaxNumber = taxNumber; 
        }
    }

    internal class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            
            UserProfile user = new UserProfile(101, "TAX-987654")
            {
                FirstName = "Богдан",
                LastName = "Павлович",
                StatusMessage = "Навчаюся в університеті"
            };

            Console.WriteLine(" Стан об'єкта після створення ");
            Console.WriteLine($"ID: {user.Id}");
            Console.WriteLine($"Податковий номер (Init-only): {user.TaxNumber}");
            Console.WriteLine($"Повне ім'я (Обчислюване): {user.FullName}");
            Console.WriteLine($"Статус (Звичайний get/set): {user.StatusMessage}\n");


            user.StatusMessage = "Виконую Завдання 3"; 
            user.FirstName = "Богдан (змінено)";      
            Console.WriteLine($"Оновлений статус: {user.StatusMessage}");
            Console.WriteLine($"Оновлене обчислюване ім'я: {user.FullName}\n");

            //  НАВМИСНІ СПРОБИ ПОРУШИТИ ОБМЕЖЕННЯ 
            
            // Спроба 1: Зміна властивості з обмеженим private set
            // user.Id = 202;
            

            // Спроба 2: Зміна init-only властивості після ініціалізації
             //user.TaxNumber = "TAX-000000";
            
            // Спроба 3: Запис у повністю обчислювану властивість
             //user.FullName = "Тарас Шевченко";
            
            Console.WriteLine("Тест виконання Task3 завершено успішно!");
        }
    }
}