// using System;
using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;

namespace DataHandler
{
    /// <summary>
    /// Helper Class for the Deserialization of JSON
    /// </summary>
    public class JsonToExercise : DeserializeJson
    {
        /// <summary>
        ///  Parses a JSON File into a Exercise
        /// </summary>
        /// <param name="path">Path which points to a JSON file</param>
        /// <returns>Exercise Object</returns>
        public Exercise _exercise(string path)
        {
            string readJson = File.ReadAllText(path);
            Exercise exercise = new Exercise();
            JsonUtility.FromJsonOverwrite (readJson, exercise);
            return exercise;
        }

        /// <summary>
        ///  Parses a JSON File into a List of Exercises
        /// </summary>
        /// <param name="path">Path which points to a JSON file</param>
        /// <returns>List of Exercise Objects</returns>
        public List<Exercise> _exercises(string path)
        {
            string readJson = File.ReadAllText(path);
            return JsonConvert
                .DeserializeObject<ExercisesContainer>(readJson)
                .exercisesList;
        }

        /// <summary>
        ///  Parses a JSON File into a training plan
        /// </summary>
        /// <param name="path">Path which points to a JSON file</param>
        ///  <returns>training plan object</returns>
        public TrainingPlan _trainingPlan(string path)
        {
            string readJson = File.ReadAllText(path);
            TrainingPlan trainingPlan = new TrainingPlan();
            JsonUtility.FromJsonOverwrite (readJson, trainingPlan);
            return trainingPlan;
        }

        /// <summary>
        ///  Parses a JSON File into a List of training plans
        /// </summary>
        /// <param name="path">Path which points to a JSON file</param>
        ///  <returns>List of training plans objects</returns>
        public List<TrainingPlan> _trainingPlans(string path)
        {
            string readJson = File.ReadAllText(path);
            return JsonConvert
                .DeserializeObject<TrainingPlanContainer>(readJson)
                .trainingPlanList;
        }
    }
}
