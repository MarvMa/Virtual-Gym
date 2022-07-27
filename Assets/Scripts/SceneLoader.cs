using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

/// <summary>
/// toggles visibility of simulation elements based on central exercise
/// </summary>
public class SceneLoader : MonoBehaviour
{
    public GameObject kettleCylinder;

    public bool kettleCylinderVisibility = false;

    public GameObject squatCylinderOne;

    public GameObject squatCylinderTwo;

    public bool squatCylinderVisibility = false;

    /// <summary>
    /// Toggle Cylinder depending on the current active exercise
    /// </summary>
    public void toggleCylinder()
    {
        if (CrossSceneInfo1.animation_id.Equals("back_squat"))
        {
            toggleSquatCyliner();
        }
        else if (CrossSceneInfo1.animation_id.Equals("sumo_high_pull"))
        {
            toggleKettleCylinder();
        }
    }

    /// <summary>
    /// Toggle Kettle Bell Exercise Cylinder
    /// </summary>
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

    /// <summary>
    /// Toggle Squat Exercise Cylinder
    /// </summary>
    private void toggleSquatCylinder()
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
}
