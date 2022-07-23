using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

/**
 * toggles visibility of simulation elements based on central exercise
 */
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
            kettleCylinderVisibility = false;
        }
        else
        {
            kettleCylinder.SetActive(true);
            kettleCylinderVisibility = true;
        }
    }
    
    private void toggleSquatCyliner()
    {
        if (squatCylinderVisibility == true)
        {
            squatCylinderOne.SetActive(false);
            squatCylinderTwo.SetActive(false);
            squatCylinderVisibility = false;

        }
        else
        {
            squatCylinderOne.SetActive(true);
            squatCylinderTwo.SetActive(true);
            squatCylinderVisibility = true;
        }
    }

    public void LoadMainScene()
    {
        // SceneManager.LoadScene( "MainScene");
        
    }
}
