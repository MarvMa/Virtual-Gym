using System;
using System.Collections.Generic;
using System.Linq;
using DataHandler;
using Newtonsoft.Json;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


public class SpawnExercises : MonoBehaviour
{
    // Public Variables
    public GameObject exerciseEnvironment;

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

    private Vector3 centerPosition = new Vector3(0, 0.1f, 0);

    private List<Exercise> _exercises;
    private List<TrainingPlan> _trainingPlans;

    private TrainingPlan _trainingPlan = new TrainingPlan();

    private String ANIMATION_TAG = "animation";

    private void Start()
    {
        _exercises = JsonHandler.getExercises();
        _trainingPlans = JsonHandler.getTrainingPlans();
        _trainingPlan = _trainingPlans.First();

        spawnPodests();
    }

    GameObject createExerciseObject(String exerciseName, Vector3 position,
        GameObject target)
    {
        var exercise = _exercises.Find(x => x.identifier.Equals(exerciseName));

        var exerciseContainer = Instantiate(exerciseEnvironment, position, Quaternion.identity);
        exerciseContainer.name = exercise.identifier;

        // Spawn Animation
        var animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise.identifier);
        var animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);
        animation.tag = ANIMATION_TAG;
        animation.transform.parent = exerciseContainer.transform;

        // Make Animation Look towards Player
        var lookPos = target.transform.position - animation.transform.position;

        var rotation = Quaternion.LookRotation(lookPos);
        animation.transform.rotation = rotation;

        var texts = exerciseContainer.GetComponentsInChildren<TMP_Text>();

        foreach (var tmpText in texts)
        {
            tmpText.gameObject.SetActive(false);
        }


        return exerciseContainer;
    }

    public GameObject[] spawnPodests()
    {
        GameObject target = GameObject.FindWithTag("MainCamera");

        GameObject[] exerciseContainer = new GameObject[_trainingPlan.exercises.Length];

        int index = 0;
        foreach (var exercise in _trainingPlan.exercises)
        {
            exerciseContainer[index] = createExerciseObject(exercise, podestPositions[index], target);
            index++;
        }

        initCenterExercise(exerciseContainer.First(), target);
        return exerciseContainer;
    }

    private void initCenterExercise(GameObject exercise, GameObject target)
    {
        Transform animationObj = Helper.FindComponentInChildWithTag<Transform>(exercise, ANIMATION_TAG);
        animationObj.gameObject.SetActive(false);
        GameObject exerciseContainer = createExerciseObject(exercise.name, centerPosition, target);
        var exerciseObj = _exercises.Find(x => x.identifier.Equals(exercise.name));
        var texts = exerciseContainer.GetComponentsInChildren<TMP_Text>();
        
        foreach (var tmpText in texts)
        {
            Debug.Log("tmpText" + tmpText.text);
            tmpText.gameObject.SetActive(false);
        }
        foreach (var text in texts)
        {
            text.text = text.name switch
            {
                "exercise-name-txt" =>
                    text.text = exerciseObj.name,
                "exercise-information-txt" =>
                    text.text = exerciseObj.background_infos,
                _ => "Kein Text vorhanden"
            };
        }
    }

    public void beforeExercise()
    {
    }

    public void nextExercise()
    {
    }
}


public class Helper

{
    public static T FindComponentInChildWithTag<T>(GameObject parent, string tag)
    {
        Transform t = parent.transform;
        foreach (Transform tr in t)
        {
            Debug.Log(tr.name + " " + tr.tag);
            if (tr.tag == tag)
            {
                Debug.Log(tr.GetType());
                return tr.GetComponent<T>();
            }
        }

        throw new Exception("No Animation in Parent: " + parent.name);
    }
}