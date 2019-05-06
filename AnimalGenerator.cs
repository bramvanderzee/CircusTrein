using System;

namespace CircusTrein {
    public static class AnimalGenerator {
        private static Random random = new Random();
        public static Animal GetRandom() {
            Array foodValues = Enum.GetValues(typeof(AnimalSize));
            var food = (AnimalDiet)random.Next(Enum.GetValues(typeof(AnimalDiet)).Length);
            var size = (AnimalSize)foodValues.GetValue(random.Next(foodValues.Length));
            var animal = new Animal(food, size);
            return animal;
        }
    }
}