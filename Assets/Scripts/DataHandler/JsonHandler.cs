using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace DataHandler
{
    public class JsonHandler
    {
        public static Exercise[] getExercises()
        {
            JsonToExercise jte = new JsonToExercise();
            return jte._exercises("Assets/Scripts/DataHandler/data/exercises.json");
        }

        private static void serialize_exercise(Exercise exercise, string file_name)
        {
            string jsonString = JsonUtility.ToJson(exercise);
            // Console.WriteLine(jsonString);
            File.WriteAllLines(file_name, new[] { jsonString });
        }

        private static void serialize_training_plan(TrainingPlan trainingPlan, string file_name)
        {
            string jsonString = JsonUtility.ToJson(trainingPlan);
            // Console.WriteLine(jsonString);
            File.WriteAllLines(file_name, new[] { jsonString });
        }

        private static void print_exercise(Exercise exercise)
        {
            // Console.WriteLine($"Name: {exercise?.name}");
            // Console.WriteLine($"muscleGroups: {exercise?.muscleGroups[0]}");
            // Console.WriteLine($"duration: {exercise?.duration}");
            // Console.WriteLine($"difficutly: {exercise?.difficulty}");
        }

        private static void print_training_plan(TrainingPlan training_plan)
        {
            // Console.WriteLine($"Name: {training_plan?.name}");
            // Console.WriteLine($"exercises: {training_plan?.exercises[0]}");
            // Console.WriteLine($"exercises: {training_plan?.exercises[1]}");
            // Console.WriteLine($"duration: {training_plan?.duration}");
            // Console.WriteLine($"difficutly: {training_plan?.difficulty}");
        }
    }
}