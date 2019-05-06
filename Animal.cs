using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CircusTrein {
    public class Animal {
        public AnimalDiet Food { get; private set; }
        public AnimalSize Size { get; private set; }

        public Animal() {}

        /// <summary>
        /// Generate an animal with these params.
        /// </summary>
        /// <param name="Food">Carnivore or herbivore.</param>
        /// <param name="Size">How big the animal is.</param>
        public Animal(AnimalDiet Food, AnimalSize Size) {
            this.Food = Food;
            this.Size = Size;
        }

        /// <summary>
        /// Returns string representation of the animal.
        /// </summary>
        public override string ToString() {
            return $"{(int)this.Size}, {Food}";
        }
    }
}
