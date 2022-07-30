using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/// <summary>
/// Includes methods for canvas activation in the podium
/// </summary>
public class MenuInPodiumActivator : MonoBehaviour
{
    public GameObject canvasInPodium;

    public GameObject canvasForInteractiveExercise;

    private MenuManager menuManager;

    /// <summary>
    /// activates the Canvas in the podium
    /// </summary>
    public void SetMenuActive()
    {
        canvasInPodium.SetActive(true);
    }

    /// <summary>
    /// activates the canvas for a interactive Exercise
    /// </summary>
    /// /// <param name="is_active"> contains the information, if the canvas should be set active or inactive</param>
    public void SetCanvasForInteractiveExercise(bool is_active)
    {
        canvasForInteractiveExercise.SetActive (is_active);
    }
}
