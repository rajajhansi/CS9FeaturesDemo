using System;
namespace CSFeaturesDemo
{
    public interface IAnimalWidget
    {
        private static int AmountToFeed = 10;
        static void SetAmountToFeed(int amount) => AmountToFeed = amount;
        public string Name { get; }
        public int Happiness { get; set; }

        public void Feed()
        {
            Happiness += AmountToFeed;
        }
}

    public class DogWidget : IAnimalWidget
    {
        public string Name => "Dog";
        public int Happiness { get; set; } = 50;

        public void Feed()
        {
            Happiness = int.MaxValue;
        }
    }

    public class CatWidget : IAnimalWidget
    {
        string IAnimalWidget.Name => "Cat";

        int IAnimalWidget.Happiness { get; set; } = 0;
    }

    public class HamsterWidget : IAnimalWidget
    {
        public string Name => "Hamster";
        public int Happiness { get; set; } = 50;
    }
    public class DefaultInterfaceMemberDemo
    {
        public static void Demo()
        {
            Console.WriteLine("DefaultInterfaceMember Demo");
            IAnimalWidget.SetAmountToFeed(20);
            var dog = new DogWidget();
            var cat = new CatWidget();
            var hamster = new HamsterWidget();

            var animals = new IAnimalWidget[] { dog, cat, hamster };

            dog.Feed();
            Console.WriteLine($"Happiness level for {dog.Name}: {dog.Happiness}");
            foreach (var animal in animals)
            {
                animal.Feed();
                Console.WriteLine($"Happiness level for {animal.Name}: {animal.Happiness}");
            }
        }

    }
}
