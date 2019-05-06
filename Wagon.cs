using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein {
    public class Wagon {
        private readonly List<Animal> animals;
        public const int maxCapacity = 10;
        public int SizeLargestCarnivore { get; private set; }
        public int SizeSmallestHerbivore { get; private set; }
        public int Count { get; private set; }
        

        public Wagon() {
            animals = new List<Animal>();
            SizeLargestCarnivore = 0;
            SizeSmallestHerbivore = maxCapacity;
        }

        public bool CanFitAnimal(Animal animal) {
            if (Count + (int)animal.Size > maxCapacity) return false;
            if ((animal.Food == AnimalDiet.Carnivore) && (SizeSmallestHerbivore <= (int)animal.Size))   return false;
            if ((animal.Food == AnimalDiet.Carnivore) && (SizeLargestCarnivore  >= (int)animal.Size))   return false;
            if ((animal.Food == AnimalDiet.Herbivore) && (SizeLargestCarnivore  >= (int)animal.Size))   return false;
            return true;
        }

        /// <summary>
        /// Adds animal to the wagon.
        /// </summary>
        /// <param name="animal">Animal to add</param>
        /// <exception cref="ArgumentOutOfRangeException">Out of enum</exception>
        public void AddAnimal(Animal animal) {
            animals.Add(animal);
            Count += (int)animal.Size;
            switch (animal.Food) {
                case AnimalDiet.Carnivore:
                    SizeLargestCarnivore = (int)animal.Size;
                    break;
                case AnimalDiet.Herbivore:
                    SizeSmallestHerbivore = (int)animal.Size;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        /// <summary>
        /// Returns string representation of the wagon.
        /// </summary>
        public override string ToString() {
            string result = "";
            foreach(Animal animal in animals) {
                result += $"{animal.ToString()}\n";
            }
            return result + "\n";
        }
    }
}
