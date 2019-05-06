using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein {
    public class Train {
        private readonly List<Wagon> wagons;
        private List<Animal> animals;

        public Train() {
            wagons = new List<Wagon>();
            animals = new List<Animal>();
        }

        /// <summary>
        /// Fill the train with animals and spread them.
        /// </summary>
        /// <param name="animals"></param>
        public void Fill(List<Animal> animals) {
            this.animals = animals;
            SpreadLoad();
        }

        /// <summary>
        /// Spread animals in wagons. 
        /// </summary>
        private void SpreadLoad() {
            var sortedAnimals = animals.OrderByDescending(x => x.Size);
            foreach(var animal in sortedAnimals) {
                bool animalSorted = false;
                foreach (var wagon in wagons) {
                    if (wagon.CanFitAnimal(animal)) {
                        wagon.AddAnimal(animal);
                        animals.Remove(animal);
                        animalSorted = true;
                    }
                }

                if(!animalSorted) {
                    var wagon = new Wagon();
                    wagon.AddAnimal(animal);
                    wagons.Add(wagon);
                    animals.Remove(animal);
                }
            }
        }

        /// <summary>
        /// Returns a string representation of the train.
        /// </summary>
        /// <returns></returns>
        public override string ToString() {
            string result = $"Wagon count: {wagons.Count}\n";
            int index = 0;
            foreach (Wagon wagon in wagons) {
                result += $"Wagon: {index}; Count: {wagon.Count}\n";
                result += $"{wagon.ToString()}";
                index++;
            }
            return result;
        }
    }
}
