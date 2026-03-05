using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace March05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Pet pet = new Pet(12, "Dog", "George");
            MyPet myPet = new MyPet(9, "Cat", "Melissa", "Grey", 4.1);
            // Pet pet2 = new myPet(..) - DA
            // MyPet myPet2 = new Pet(..) - NET
            Pet hiddenPet = new MyPet(8, "Horse", "Bella", "Brown", 350.0);

            Pet[] pets = new Pet[] {myPet, hiddenPet};

            for (int i = 0; i < pets.Length; i++)
            {
                if (pets[i] is MyPet)
                {
                    MyPet p = pets[i] as MyPet;
                    Console.WriteLine(p.Coat);
                }
            }

            for (int i = 0; i < pets.Length; i++)
            {
                MyPet p = pets[i] as MyPet;
                if (p != null)
                {
                    Console.WriteLine(p.Coat);
                }
            }

            // hiddenPet.Greeting(); // из наследника
            // hiddenPet.Print(); // из базовго класса

            // pet.Greeting();
            // pet.Print();
            // myPet.Greeting();
            // myPet.Print();
        }
    }

    public abstract class Pet // базовый класс
    { 
        protected int _age;
        protected string _petType;
        protected string _name;

        public abstract string AbstractProperty { get;}
        
        public Pet(int age, string petType, string name)
        {
            _age = age;
            _petType = petType;
            _name = name;
        }

        public virtual void Greeting() // виртуальным делаем метод, который будем менять в классе-наследнике
        {
            Console.WriteLine("I have a pet.");
        }

        public void Print()
        {
            Console.WriteLine($"Pet: {_name}, Age: {_age}, PetType: {_petType}.");
            Console.WriteLine();
        }

        public abstract void Bye();
    }

    public class MyPet : Pet // класс-наследник
    {
        private string _coat;
        private double _weight;

        public override string AbstractProperty => "Example.";
        public string Coat => _coat;
        public MyPet(int age, string petType, string name, string coat) : base(age, petType, name)
        {
            _age += 1;
            _coat = coat;
            _weight = 4.1;
        }

        public MyPet(int age, string petType, string name, string coat, double weight) : this(age, petType, name, coat)
        {
            _weight = weight;
        }

        public override void Greeting() // override - переопределение
        {
            Console.WriteLine("Meow!");
        }
        
        public new void Print() // сокрытие метода
        {
            Console.WriteLine($"Pet: {_name}, Age: {_age}, PetType: {_petType}, Coat: {_coat}, Weight: {_weight}.");
        }

        public override void Bye()
        {
            Console.WriteLine("Bye!");
        }
    }
}