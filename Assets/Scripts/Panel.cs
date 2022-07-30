using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Contains method to setup the configuration menu
/// </summary>
public class Panel : MonoBehaviour
{
    public Canvas canvas = null;
    private MenuManager menuManager = null;


    /// <summary>
    /// Initialization of the menu manager
    /// </summary>
    public void Setup(MenuManager menuManager)
    {
        this.menuManager = menuManager;
    }

    /// <summary>
    /// Configuration menu visibility on
    /// </summary>
    public void Show()
    {
        //canvas.enabled = true;
        canvas.gameObject.SetActive(true);
    }

    /// <summary>
    /// Configuration menu visibility off
    /// </summary>
    public void Hide()
    {
        //canvas.enabled = false;
        canvas.gameObject.SetActive(false);

    }
}
