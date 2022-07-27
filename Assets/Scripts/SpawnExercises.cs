using System;
using System.Collections.Generic;
using System.Linq;
using DataHandler;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    /// Public Variables
    public GameObject exerciseEnvironment;
    public GameObject exerciseEnvironmentCenter;
    /// Private Variables
    private List<String> _trainingPlan;
    private GameObject _target;
    private GameObject _currentMidAnimation;
    private MenuInPodiumActivator menuInPodiumActivator;

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

    private void Start()
    {
        _exercises = JsonHandler.getExercises();
        _trainingPlans = JsonHandler.getTrainingPlans();
        menuInPodiumActivator = GameObject.FindWithTag("GameManager").GetComponent<MenuInPodiumActivator>();
    }

    /// <summary>
    /// Creates a Container with the podium, light and canvas
    /// </summary>
    /// <param name="exerciseName"> name of the exercise</param>
    /// <param name="position">position for the container</param>
    /// <param name="center"> determines if the object is in the center of the scene</param>
    /// <returns> container object</returns>
    GameObject createExerciseObject(String exerciseName, Vector3 position, bool center)
    {
        var exercise = _exercises.Find(x => x.identifier.Equals(exerciseName));
        GameObject exerciseContainer;
        if (center)
        {
            exerciseContainer  = Instantiate(exerciseEnvironmentCenter, position, Quaternion.identity);
        }
        else
        {
            exerciseContainer = Instantiate(exerciseEnvironment, position, Quaternion.identity);
        }
        exerciseContainer.name = exercise.identifier;

        /// Spawns Animation  
        var animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise.identifier);
        var animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);
        animation.transform.parent = exerciseContainer.transform;

        /// Make Animation Look towards Player
        var lookPos = _target.transform.position - animation.transform.position;

        var rotation = Quaternion.LookRotation(lookPos);
        animation.transform.rotation = rotation;

        var texts = exerciseContainer.GetComponentsInChildren<TMP_Text>();
        

        return exerciseContainer;
    }

    /// <summary>
    /// Spawns the Podiums of the Exercises
    /// </summary>
    /// <param name="trainingPlan"></param>
    /// <returns></returns>
    public List<GameObject> spawnPodiums(List<String> trainingPlan)
    {
        Destroy(_currentMidAnimation);
        if (CrossSceneInfo1.animation_id == null)
        {
            CrossSceneInfo1.animation_id = trainingPlan.First();
        }
        
        _trainingPlan = trainingPlan;
        _target = GameObject.FindWithTag("MainCamera");

        List<GameObject> exerciseContainer = new List<GameObject>();

        int index = 0;
        foreach (var exercise in trainingPlan)
        {
            // GameObject singleContainer;
            if (exercise.Equals(CrossSceneInfo1.animation_id))
                exerciseContainer.Add(createExerciseObject(exercise, _podestPositions[index], true));
            else
            {
                exerciseContainer.Add(createExerciseObject(exercise, _podestPositions[index], false));
            }
            index++;
        }

        _currentMidAnimation = initCenterExercise(exerciseContainer.First().name);
        CrossSceneInfo1.animation_id = exerciseContainer.First().name;
        SetSimulationButtonVisibility();
        exerciseContainer.Add(_currentMidAnimation);
        return exerciseContainer;
    }

    /// <summary>
    /// Switch from the current exercise which is in the middle to the next exercise in the current training plan
    /// </summary>
    private String GetNextExercise()
    {
        String currentAnimationId = CrossSceneInfo1.animation_id;
        int index = _trainingPlan.FindIndex(x => x.Equals(currentAnimationId));
        index++;

        int newIndex = index % _trainingPlan.Count;
        return _trainingPlan[newIndex];
    }
    /// <summary>   
    ///  Switch from the current exercise which is in the middle to the exercise which have been before the current one
    /// </summary>
    private String GetPreviousExercise()
    {
        String currentAnimationId = CrossSceneInfo1.animation_id;
        int index = _trainingPlan.FindIndex(x => x.Equals(currentAnimationId));
        index--;
        if (index < 0)
        {
            index += _trainingPlan.Count;
        }

        int newIndex = index % _trainingPlan.Count;
        return _trainingPlan[newIndex];
    }

    public void GoRightNew()
    {
        Destroy(_currentMidAnimation);
        String nextExercise = GetNextExercise();
        CrossSceneInfo1.animation_id = nextExercise;
        _currentMidAnimation = initCenterExercise(nextExercise);
        SetSimulationButtonVisibility();
    }

    private void SetSimulationButtonVisibility()
    {
        if (CrossSceneInfo1.animation_id.Equals("sumo_high_pull") || CrossSceneInfo1.animation_id.Equals("back_squat"))
        {
            menuInPodiumActivator.SetCanvasForInteractiveExercise(true);
        } else
        {
            menuInPodiumActivator.SetCanvasForInteractiveExercise(false);
        }
    }
    public void GoLeftNew()
    {
        Destroy(_currentMidAnimation);
        String previousExercise = GetPreviousExercise();
        CrossSceneInfo1.animation_id = previousExercise;
        _currentMidAnimation = initCenterExercise(previousExercise);
        SetSimulationButtonVisibility();
    }

    /// <summary>
    /// Creates the Container for the Center exercise 
    /// </summary>
    /// <param name="exercise"> name of the exercise </param>
    /// <returns>Container Object of the Center exercise</returns>
    private GameObject initCenterExercise(String exercise)
    {
        GameObject exerciseContainer;
            exerciseContainer = createExerciseObject(exercise, _centerPosition, true);
   
        var exerciseObj = _exercises.Find(x => x.identifier.Equals(exercise));
        var texts = exerciseContainer.GetComponentsInChildren<TMP_Text>();

        foreach (var text in texts)
        {
            text.gameObject.SetActive(true);
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


}