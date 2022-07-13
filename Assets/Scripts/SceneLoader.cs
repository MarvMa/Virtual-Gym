using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    // public SpawnExercises spawnExercises;
    public GameObject kettleCylinder;
    public bool kettleCylinderVisibility = false;
    public GameObject squatCylinderOne;
    public GameObject squatCylinderTwo;
    public bool squatCylinderVisibility = false;

    void Start()
    {
        // spawnExercises = GameObject.FindWithTag("GameManager").GetComponent<SpawnExercises>();
    } 
    
    // public void LoadScene()
    // {
    //     SceneManager.LoadScene( GetInteractiveExercise());
    // }
    //
    // private String GetInteractiveExercise()
    // {
    //     int scene = spawnExercises.CheckForInteractive();
    //
    //     if (scene ==1)
    //     {
    //         return "SquatScene";
    //     }
    //
    //     if (scene == 2)
    //     {
    //         return "KettleScene";
    //     }
    //
    //     return "MainScene";
    // }

    public void toggleCylinder()
    {
        if (CrossSceneInfo1.animation_id.Equals("back_squat"))
        {
            toggleSquatCyliner();
        }
        else if (CrossSceneInfo1.animation_id.Equals("sumo_high_pull"))
        {
            toggleKettleCyliner();
        }
    }

    private void toggleKettleCyliner()
    {
        if (kettleCylinderVisibility)
        {
            kettleCylinder.SetActive(false);

        }
        else
        {
            kettleCylinder.SetActive(true);
        }
    }
    
    private void toggleSquatCyliner()
    {
        if (squatCylinderVisibility)
        {
            squatCylinderOne.SetActive(false);
            squatCylinderTwo.SetActive(false);

        }
        else
        {
            squatCylinderOne.SetActive(true);
            squatCylinderTwo.SetActive(true);
        }
    }

    public void LoadMainScene()
    {
        // SceneManager.LoadScene( "MainScene");
        
    }
}
