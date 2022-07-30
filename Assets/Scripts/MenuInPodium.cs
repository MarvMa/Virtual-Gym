using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class which contains the logic for the Menu in the Podium
/// </summary>
public class MenuInPodium : MonoBehaviour
{
    public MenuManager menuManager;

    private void Start()
    {
        menuManager =
            GameObject.FindWithTag("Canvas").GetComponent<MenuManager>();
    }

    /// <summary>
    /// Button event method which opens the Pause Menu
    /// </summary>
    public void onPushMenuButton()
    {
        menuManager.PanelPauseÜbersichtButton();
    }
}
