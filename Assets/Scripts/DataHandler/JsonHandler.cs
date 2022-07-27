using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DataHandler
{
    public class JsonHandler
    {
        /// <summary>
        /// get all exercise elements from a json file
        /// </summary>
        /// <returns>List of exercise objects</returns>
        public static List<Exercise> getExercises()
        {
            JsonToExercise jte = new JsonToExercise();
            return jte
                ._exercises("Assets/Scripts/DataHandler/data/exercises.json");
        }

        /// <summary>
        /// get all training plan elements from a json file
        /// </summary>
        /// <returns>List of trainins plan objects</returns>
        public static List<TrainingPlan> getTrainingPlans()
        {
            JsonToExercise jte = new JsonToExercise();
            return jte
                ._trainingPlans("Assets/Scripts/DataHandler/data/trainingsplan.json");
        }

        private static void print_exercise(Exercise exercise)
        {
            Console.WriteLine($"Name: {exercise?.name}");
            Console.WriteLine($"muscleGroups: {exercise?.muscleGroups[0]}");
            Console.WriteLine($"duration: {exercise?.duration}");
            Console.WriteLine($"difficutly: {exercise?.difficulty}");
        }

        private static void print_training_plan(TrainingPlan training_plan)
        {
            Console.WriteLine($"Name: {training_plan?.name}");
            Console.WriteLine($"exercises: {training_plan?.exercises[0]}");
            Console.WriteLine($"exercises: {training_plan?.exercises[1]}");
            Console.WriteLine($"duration: {training_plan?.duration}");
            Console.WriteLine($"difficutly: {training_plan?.difficulty}");
        }
    }
}
