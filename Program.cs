using System;


namespace Lab1
{
    public class BaseClass
    {
        public int Public = 1;
        private int priv = 2;
        protected int protect = 3;
        internal int intern = 4;
        private protected int privprotect = 5;
        protected internal int protectintern = 6;


        public void TestInternal()
        {
            int a = Public;
            int b = priv;
            int c = protect;
            int d = intern;
            int e = privprotect;
            int f = protectintern;
        }
    }

    public class DerivedClass : BaseClass
    {
        public void TestDerived()
        {
            int a = Public;
            //int b = priv;  //Помилка CS0122: private недоступний у похідному класі
            int c = protect;
            int d = intern;
            int e = privprotect;
            int f = protectintern;
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            BaseClass obj = new BaseClass();
            int a = obj.Public;
            // int b = obj.priv;        // Помилка CS0122: private недоступний ззовні
            // int c = obj.protect;     // Помилка CS0122: protected недоступний клієнту
            int d = obj.intern;
            // int e = obj.privprotect; // Помилка CS0122: private protected недоступний не-нащадку
            int f = obj.protectintern;
            
            Console.WriteLine("Компіляція та запуск успішні!");
        }
        
    }
}