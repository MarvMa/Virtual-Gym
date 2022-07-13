using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInPodiumActivator : MonoBehaviour
{
    public GameObject canvasInPodium;
    public GameObject canvasForInteractiveExercise;
    private MenuManager menuManager;
    
    public void SetMenuActive()
    {
        canvasInPodium.SetActive(true);
    }
    
    public void SetcanvasForInteractiveExerciseActive()
    {
        canvasForInteractiveExercise.SetActive(true);
    }

}
