using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuInPodium : MonoBehaviour
{
    public MenuManager menuManager;
    private void Start()
    {
        menuManager = GameObject.FindWithTag("Canvas").GetComponent<MenuManager>();
    }

    public void onPushMenuButton()
    {
        menuManager.PanelPauseÜbersichtButton();
    }
}
