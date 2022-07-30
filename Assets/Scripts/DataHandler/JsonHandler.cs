using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DataHandler
{
    /// <summary>
    /// Class which retrieves die exercises and trainingsplan from a json file
    /// </summary>
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
        public static List<TrainingPlan> getTrainingPlans()
        {
            JsonToExercise jte = new JsonToExercise();
            return jte
                ._trainingPlans("Assets/Scripts/DataHandler/data/trainingsplan.json");
        }

        /// <summary>
        ///  Prints the exercises to the console
        /// </summary>
        /// <param name="exercise">Exercise to print</param>
        private static void print_exercise(Exercise exercise)
        {
            Console.WriteLine($"Name: {exercise?.name}");
            Console.WriteLine($"muscleGroups: {exercise?.muscleGroups[0]}");
            Console.WriteLine($"duration: {exercise?.duration}");
            Console.WriteLine($"difficutly: {exercise?.difficulty}");
        }
        /// <summary>
        /// Prints the trainingsplans to the console  
        /// </summary>
        /// <param name="training_plan">Trainingsplan to print</param>
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
