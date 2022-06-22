using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Panel : MonoBehaviour
{
    public Canvas canvas = null;
    private MenuManager menuManager = null;


    
    public void Setup(MenuManager menuManager)
    {
        this.menuManager = menuManager;
    }
    
    public void Show()
    {
        //canvas.enabled = true;
        canvas.gameObject.SetActive(true);
    }
    
    public void Hide()
    {
        //canvas.enabled = false;
        canvas.gameObject.SetActive(false);

    }
}
