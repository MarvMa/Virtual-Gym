using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Panel panelStart = null;
    public Panel panelChoosePlan = null;
    public Panel panelChooseModifyExp = null;
    public Panel panelChooseModifyDuration = null;
    public Panel panelChooseStart = null;
    public Panel panelSettings = null;
    public Panel panelPauseMenu = null;

    private int trainingsPlan;
    private int trainingsExperience;
    private int trainingsDuration;

    private void Start()
    {
        HideAll();
        panelStart.Show();
    }
    
    // menu
    public void menuButtonTrainingsplan()
    {
        HideAll();
        panelChoosePlan.Show();
    }

    public void menuButtonSettings()
    {
        HideAll();
        panelSettings.Show();
    }
    
    public void menuButtonExit()
    {
        HideAll();
        //todo: implement exit
    }
    
    //panel Start 
    public void pressStartButton()
    {
        HideAll();
        panelSettings.Show();
    }
    
    //panel panelChoosePlan
    public void GanzkoerperTrainingButton()
    {
        trainingsPlan = 1; 
        HideAll();
        panelChooseModifyExp.Show();
    }
    
    public void RückenuebungenButton()
    {
        trainingsPlan = 2; 
        HideAll();
        panelChooseModifyExp.Show();
    }
    
    public void FreiesTrainingButton()
    {
        trainingsPlan = 0; 
        HideAll();
        panelChooseModifyExp.Show();
    }
    
    // panelChooseModifyExp
    public void panelChooseModifyExpOne()
    {
        trainingsExperience = 1;
        HideAll();
        panelChooseModifyDuration.Show();
    }
    
    public void panelChooseModifyExpTwo()
    {
        trainingsExperience = 2;
        HideAll();
        panelChooseModifyDuration.Show();
    }
    
    public void panelChooseModifyExpThree()
    {
        trainingsExperience = 3;
        HideAll();
        panelChooseModifyDuration.Show();
    }
    
    //panelChooseModifyDuration
    public void panelChooseModifyDurOne()
    {
        trainingsDuration = 1;
        HideAll();
        panelChooseStart.Show();
    }
    
    public void panelChooseModifyDurTwo()
    {
        trainingsDuration = 2;
        HideAll();
        panelChooseStart.Show();
    }
    
    public void panelChooseModifyDurThree()
    {
        trainingsDuration = 3;
        HideAll();
        panelChooseStart.Show();
    }
    
    //genTrainingsplan
    
    private void HideAll()
    {
        panelStart.Hide();
        panelChoosePlan.Hide();
        panelChooseModifyExp.Hide();
        panelChooseModifyDuration.Hide();
        panelChooseStart.Hide();
        panelSettings.Hide();
        panelPauseMenu.Hide();
    }
}