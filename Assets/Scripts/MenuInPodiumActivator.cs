using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInPodiumActivator : MonoBehaviour
{
    public Canvas canvas;
    public GameObject canvasInPodium;
    public MenuManager menuManager;

    private void Start()
    {
        menuManager = GameObject.FindWithTag("Canvas").GetComponent<MenuManager>();
    }
    public void SetMenuActive()
    {
        canvasInPodium.SetActive(true);
    }
    public void onPushMenuButton()
    {
        menuManager.PanelPauseÜbersichtButton();
    }

    public void onPushForwardButton()
    {
        
    }

}
