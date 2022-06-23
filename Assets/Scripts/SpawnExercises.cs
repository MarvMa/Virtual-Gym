using System;
using System.Collections.Generic;
using DataHandler;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    // Public Variables
    public GameObject podestGameObject;
    public GameObject spotLight;

    private Vector3[] podestPositions = new[]
    {
        new Vector3(10, 0.1f, 10),
        new Vector3(14, 0.1f, 0),
        new Vector3(10, 0.1f, -10),
        new Vector3(0, 0.1f, -14),
        new Vector3(-10, 0.1f, -10),
        new Vector3(-14, 0.1f, 0),
        new Vector3(-10, 0.1f, 10),
        new Vector3(0, 0.1f, 14),
    };
    
    public class WeatherForecast
    {
        public DateTimeOffset Date { get; set; }
        public int TemperatureCelsius { get; set; }
        public string? Summary { get; set; }
    }

    void Start()
    {
        GameObject[] podests = spawnPodests();
        List<Exercise> exercises = JsonHandler.getExercises();
        List<TrainingPlan> trainingPlans = JsonHandler.getTrainingPlans();
        if (exercises != null)
        {
            foreach (var exercise in exercises)
            {
                // Debug.Log("Exercise" + exercise);
                Debug.Log(exercise.identifier);
            }
            Debug.Log("Training plan first exercise: " + trainingPlans[0].exercises[0]);
        }
        else
        {
            Debug.Log("exercises are empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    GameObject[] spawnPodests()
    {
        GameObject[] podests = new GameObject[podestPositions.Length];
        int index = 0;
        foreach (var position in podestPositions)
        {
            podests[index] = Instantiate(podestGameObject, position, Quaternion.identity);
            GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
            light.transform.Rotate(90, 0, 0);
            index++;
        }

        return podests;
    }
}