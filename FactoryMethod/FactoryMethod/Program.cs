using System;

namespace FactoryMethod
{
    //абстрактний клас творця, який має абстрактний метод FactoryMethod, що приймає тип продукта
    public abstract class Creator
    {
        public abstract Product FactoryMethod(int type);
    }

    public class ConcreteCreator : Creator
    {
        public override Product FactoryMethod(int type)
        {
            switch (type)
            {
                //повертає об'єкт A, якщо type==1
                case 1: return new ConcreteProductA();
                //повертає об'єкт B, якщо type==2  
                case 2: return new ConcreteProductB();
                default: throw new ArgumentException("Invalid type.", "type");
            }
        }
    }

    public abstract class Product { public abstract void Info(); } //абстрактний клас продукт

    //конкретні продукти з різною реалізацією
    public class ConcreteProductA : Product
    {
        public override void Info()
        {
            Console.WriteLine("Ford");
        }
    }

    public class ConcreteProductB : Product 
    {
        public override void Info()
        {
            Console.WriteLine("Toyota");
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            Creator creator = new ConcreteCreator();
            for (int i = 1; i <= 2; i++)
            {
                //створюємо спочатку продукт з типом 1, потім з типом 2
                var product = creator.FactoryMethod(i);
                product.Info();
            }
            Console.ReadKey();
        }
    }
}
