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


    GameObject createExerciseObject(List<Exercise> exercises, String exerciseName, Vector3 position, GameObject target)
    {
        Exercise exercise = exercises.Find(x => x.identifier.Equals(exerciseName));

        GameObject exerciseContainer = new GameObject(exercise.name);
        exerciseContainer.transform.position = position;
        // Spawn Podest
        GameObject podest = Instantiate(podestGameObject, position, Quaternion.identity);
        podest.transform.parent = exerciseContainer.transform;

        // Spawn Spotlights
        GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.Euler(90, 0, 0));
        light.transform.parent = exerciseContainer.transform;

        // Spawn Animation
        GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise.identifier);

        GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);


        // Make Animation Look towards Player
        var lookPos = target.transform.position - animation.transform.position;

        Quaternion rotation = Quaternion.LookRotation(lookPos);
        animation.transform.rotation = rotation;
        animation.transform.parent = exerciseContainer.transform;
        return exerciseContainer;
    }

    public GameObject[] spawnPodests()
    {
        exercises = JsonHandler.getExercises();
        trainingPlans = JsonHandler.getTrainingPlans();
        trainingPlan = trainingPlans.First();

        GameObject target = GameObject.FindWithTag("MainCamera");

        GameObject[] podests = new GameObject[podestPositions.Length];

        int index = 0;
        foreach (var exercise in trainingPlan.exercises)
        {
            createExerciseObject(exercises, exercise, podestPositions[index], target);
            index++;
        }

        return podests;
    }
}