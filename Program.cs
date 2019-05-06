using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein {
    public class Program {
        private const int maxAnimals = 10;
        private static Train train;
        public static List<Animal> animals;

        private static void Main(string[] args) {
            train = new Train();
            animals = new List<Animal>();

            RunRandom();
        }

        private static void RunSetList() {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            GenerateAnimals();
            train.Fill(animals);
            watch.Stop();
            Console.WriteLine(train.ToString());
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }
        

        private static void RunRandom() {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            GenerateAnimals();
            train.Fill(animals);
            watch.Stop();
            Console.WriteLine(train.ToString());
            Console.WriteLine(watch.ElapsedMilliseconds);
            Console.ReadKey();
        }

        /// <summary>
        /// Generates random animals
        /// </summary>
        private static void GenerateAnimals() {
            for(int i = 0; i < maxAnimals; i++) {
                animals.Add(AnimalGenerator.GetRandom());
            }
        }
    }
}
