using System;
using System.Collections.Generic;
using System.Linq;
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
        new Vector3(0, 0.1f, 0),
        new Vector3(10, 0.1f, 10),
        new Vector3(14, 0.1f, 0),
        new Vector3(10, 0.1f, -10),
        new Vector3(0, 0.1f, -14),
        new Vector3(-10, 0.1f, -10),
        new Vector3(-14, 0.1f, 0),
        new Vector3(-10, 0.1f, 10),
        new Vector3(0, 0.1f, 14),
    };

    private List<Exercise> exercises;
    private List<TrainingPlan> trainingPlans;

    private TrainingPlan trainingPlan = new TrainingPlan();

    
    public GameObject[] spawnPodests()
    {
        exercises = JsonHandler.getExercises();
        trainingPlans = JsonHandler.getTrainingPlans();
        trainingPlan = trainingPlans.First();
        
        GameObject[] podests = new GameObject[podestPositions.Length];
        int index = 0;
        String[] tpExercises = trainingPlan.exercises;
        foreach (var exercise in tpExercises)
        {
            Vector3 position = podestPositions[index];
            // Spawn Podests
            podests[index] = Instantiate(podestGameObject, position, Quaternion.identity);
            // Spawn Spotlights
            GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
            light.transform.Rotate(90, 0, 0);
            
            // Spawn Animation
            GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise);
            Debug.Log(exercise);
            GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
                Quaternion.identity);
            index++;
        }

        return podests;
    }
}