// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//

using System.IO;
using UnityEngine;

public class Demonstration
{
//    //TODO: hintergrundinfos + ausführungsinfos bei exercises
        public static void Main()
            {
                // var synthesizer = new SpeechSynthesizer();
                // synthesizer.SetOutputToDefaultAudioDevice();
                // synthesizer.Speak("All we need to do is to make sure we keep talking");
               
                var bizep_curl = new Exercise
                {
                    name = "Bizep Curl",
                    muscleGroups = new[] { "bizep", "forearm" },
                    duration = 10,
                    difficulty = Difficulty.Easy,
                    background_info = "background",
                    execution_info = "stabilize elbow"
                };
               
                var bench_press = new Exercise
                {
                    name = "Bench Press",
                    muscleGroups = new[] { "pectorals", "triceps" },
                    duration = 10,
                    difficulty = Difficulty.Medium,
                    background_info = "background",
                    execution_info = "stabilize back"
                };

                var trainingPlan = new TrainingPlan()
                {
                    name = "my_plan",
                    difficulty = Difficulty.Hard,
                    exercises = new[] { "bizep_curl", "bench_press" },
                    duration = 10
                };

                string training_plan_fileName = "training_plan";
                string bizep_curl_filename = "bizep_curl";
                string bench_press_filename = "bench_press";
                serialize_exercise(bizep_curl, bizep_curl_filename);
                serialize_exercise(bench_press, bench_press_filename);
                serialize_training_plan(trainingPlan, training_plan_fileName);
               
                var jsonToExercise = new JsonToExercise();
                var deserializedTrainingPlan = jsonToExercise._trainingPlan(training_plan_fileName);
                var deseriazed_bizep_curl = jsonToExercise._exercise(deserializedTrainingPlan.exercises[0]);
                var deseriazed_bench_press = jsonToExercise._exercise(deserializedTrainingPlan.exercises[1]);
                print_training_plan(deserializedTrainingPlan);
                print_exercise(deseriazed_bizep_curl);
                print_exercise(deseriazed_bench_press);
            }
       
        private static void serialize_exercise(Exercise exercise , string file_name)
        {
            string jsonString = JsonUtility.ToJson(exercise);
            // Console.WriteLine(jsonString);
            File.WriteAllLines(file_name, new []{jsonString});
        }
           
        private static void serialize_training_plan(TrainingPlan trainingPlan , string file_name)
        {
            string jsonString = JsonUtility.ToJson(trainingPlan);
            // Console.WriteLine(jsonString);
            File.WriteAllLines(file_name, new []{jsonString});
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
