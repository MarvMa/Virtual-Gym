using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public SpawnExercises spawnExercises;

    void Start()
    {
        spawnExercises = GameObject.FindWithTag("GameManager").GetComponent<SpawnExercises>();
    } 
    
    public void LoadScene()
    {
        SceneManager.LoadScene( GetInteractiveExercise());
    }

    private String GetInteractiveExercise()
    {
        int scene = spawnExercises.CheckForInteractive();

        if (scene ==1)
        {
            return "SquatScene";
        }

        if (scene == 2)
        {
            return "KettleScene";
        }

        return "MainScene";
    }

    public void LoadMainScene()
    {
        SceneManager.LoadScene( "MainScene");
    }
}
