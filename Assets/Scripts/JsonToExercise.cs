// using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.Json;

public class JsonToExercise : DeserializeJson
{
    public Exercise _exercise(string path)
    { 
        string readJson = File.ReadAllText(path);
        Exercise exercise = new Exercise();
        JsonUtility.FromJsonOverwrite(readJson, exercise);
        return exercise;
    }

    public TrainingPlan _trainingPlan(string path)
    {
        string readJson = File.ReadAllText(path);
        TrainingPlan trainingPlan = new TrainingPlan();
        JsonUtility.FromJsonOverwrite(readJson, trainingPlan);
        return trainingPlan;
    }
}
