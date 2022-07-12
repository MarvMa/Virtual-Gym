using System;
using System.Collections.Generic;
using System.Linq;
using DataHandler;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    // Public Variables
    public GameObject exerciseEnvironment;
    private List<String> _trainingPlan;
    private GameObject _target;
    private GameObject _currentMidAnimation;

    private Vector3[] _podestPositions = new[]
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

    private Vector3 _centerPosition = new Vector3(0, 0.1f, 0);

    private List<Exercise> _exercises;
    private List<TrainingPlan> _trainingPlans;

    private String ANIMATION_TAG = "animation";

    private void Start()
    {
        _exercises = JsonHandler.getExercises();
        _trainingPlans = JsonHandler.getTrainingPlans();
    }

    GameObject createExerciseObject(String exerciseName, Vector3 position)
    {
        var exercise = _exercises.Find(x => x.identifier.Equals(exerciseName));

        var exerciseContainer = Instantiate(exerciseEnvironment, position, Quaternion.identity);
        exerciseContainer.name = exercise.identifier;

        // Spawn Animation
        var animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise.identifier);
        var animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);
        // animation.tag = ANIMATION_TAG;
        animation.transform.parent = exerciseContainer.transform;

        // Make Animation Look towards Player
        var lookPos = _target.transform.position - animation.transform.position;

        var rotation = Quaternion.LookRotation(lookPos);
        animation.transform.rotation = rotation;

        var texts = exerciseContainer.GetComponentsInChildren<TMP_Text>();

        foreach (var tmpText in texts)
        {
            tmpText.gameObject.SetActive(false);
        }


        return exerciseContainer;
    }

    public List<GameObject> spawnPodests(List<String> trainingPlan)
    {
        _trainingPlan = trainingPlan;
        _target = GameObject.FindWithTag("MainCamera");

        //GameObject[] exerciseContainer = new GameObject[trainingPlan.Count];
        List<GameObject> exerciseContainer = new List<GameObject>();
        
        int index = 0;
        foreach (var exercise in trainingPlan)
        {
            exerciseContainer.Add(createExerciseObject(exercise, _podestPositions[index]));
            index++;
        }

        _currentMidAnimation = initCenterExercise(exerciseContainer.First().name);
        CrossSceneInfo1.animation_id = exerciseContainer.First().name;
        return exerciseContainer;
    }

    private String getNextExercise()
    {
        String current_animation_id = CrossSceneInfo1.animation_id;
        int index = _trainingPlan.FindIndex(x => x.Equals(current_animation_id));
        index++;
        Debug.Log("index: " + index);
        Debug.Log("training plan länge: " + _trainingPlan.Count);
        
        int new_index = index % _trainingPlan.Count;
        Debug.Log("new index: " + new_index);
        return _trainingPlan[new_index];
    }

    public void goRightNew()
    {
        Destroy(_currentMidAnimation);
        Debug.Log("animation id: " + CrossSceneInfo1.animation_id);
        String next_exercise = getNextExercise();
        CrossSceneInfo1.animation_id = next_exercise;
        _currentMidAnimation = initCenterExercise(next_exercise);
    }

    private GameObject initCenterExercise(String exercise)
    {
        
        // Transform animationObj = Helper.FindComponentInChildWithTag<Transform>(exercise, ANIMATION_TAG);
        // animationObj.gameObject.SetActive(false);
        GameObject exerciseContainer = createExerciseObject(exercise, _centerPosition);
        var exerciseObj = _exercises.Find(x => x.identifier.Equals(exercise));
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

        return exerciseContainer;
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