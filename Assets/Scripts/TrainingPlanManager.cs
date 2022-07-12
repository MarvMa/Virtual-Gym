// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
//
// public class TrainingPlanManager : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
//         
//     }
//
//     // Update is called once per frame
//     void Update()
//     {
//         
//     }
//     
//         public List<String> ReturnTrainingPlan()
//     {
//         //Get both trainingsplans
//         filteredTrainingsPlan = JsonHandler.getTrainingPlans();
//         //Select the trainingplan and sort the exercises by descending difficulty
//         switch (trainingsExperience)
//         {
//             case 0:
//                 //0-1-2
//                 availableExercises = filteredTrainingsPlan[trainingsPlan - 1].exercises.OrderBy(o => o.exerciseDifficulty).ToList();
//                 break;
//             //1-0-2 kind of unnessesary because there will always be 9 elements with difficulty 1 and 0 and 2 will never be included
//             case 1:
//                 availableExercises = filteredTrainingsPlan[trainingsPlan - 1].exercises.OrderByDescending(o => o.exerciseDifficulty).ToList();
//                 helper = availableExercises.Where(o => o.exerciseDifficulty == 2).ToList();
//                 availableExercises = availableExercises.Except(helper).ToList();
//                 availableExercises.AddRange(helper);
//                 break;
//             //2-1-0
//             case 2:
//                 availableExercises = filteredTrainingsPlan[trainingsPlan - 1].exercises.OrderByDescending(o => o.exerciseDifficulty).ToList();
//                 break;
//
//         }
//         //Select amount of exercises
//         switch (trainingsDuration)
//         {
//             case 0:
//                 availableExercises = availableExercises.Take(3).ToList();
//                 break;
//
//             case 1:
//                 availableExercises = availableExercises.Take(6).ToList();
//                 break;
//
//             case 2:
//                 availableExercises = availableExercises.Take(9).ToList();
//                 break;
//
//         }
//
//         exercisesAsStrings = new List<string>();
//         //Return only the string names of the exercises in a list
//         foreach (var item in availableExercises)
//         {
//
//             exercisesAsStrings.Add(item.exerciseName);
//         }
//         Debug.Log(exercisesAsStrings.Count);
//         return exercisesAsStrings;
//
//     }
// }
