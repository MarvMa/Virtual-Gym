// using System;

using System;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using Newtonsoft.Json;

namespace DataHandler
{
    public class JsonToExercise : DeserializeJson
    {
        public Exercise _exercise(string path)
        {
            string readJson = File.ReadAllText(path);
            Exercise exercise = new Exercise();
            JsonUtility.FromJsonOverwrite(readJson, exercise);
            return exercise;
        }

        public List<Exercise> _exercises(string path)
        {
            string readJson = File.ReadAllText(path);
            // return JsonHelper.FromJson<Exercise>(readJson);
            return JsonConvert.DeserializeObject<ExercisesContainer>(readJson).exercisesList;
        }
        // public Exercise[] _exercises(string path)
        // {
        //     string readJson = File.ReadAllText(path);
        //     Debug.Log(readJson);
        //     JsonWrapper wrapper = new JsonWrapper();
        //     JsonUtility.FromJsonOverwrite(readJson, wrapper);
        //     Debug.Log(wrapper.Exercises);
        //     return wrapper.Exercises;
        // }

        public TrainingPlan _trainingPlan(string path)
        {
            string readJson = File.ReadAllText(path);
            TrainingPlan trainingPlan = new TrainingPlan();
            JsonUtility.FromJsonOverwrite(readJson, trainingPlan);
            return trainingPlan;
        }

        public List<TrainingPlan> _trainingPlans(string path)
        {
            string readJson = File.ReadAllText(path);
            return JsonConvert.DeserializeObject<TrainingPlanContainer>(readJson).trainingPlanList;
        }
    }
}