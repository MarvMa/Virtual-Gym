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

    private CurrentPanelEnum _currentPanel;
    
    private enum CurrentPanelEnum
    {
        PanelStart,
        PanelChoosePlan,
        PanelChooseModifyExp,
        PanelChooseModifyDuration,
        PanelChooseStart,
        PanelPauseMenu
    }

    private void Start()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelStart; 
        panelStart.Show();
    }
    
    // menu

    public void MenuButtonSettings()
    {
        HideAll();
        panelSettings.Show();
    }
    
    public void MenuButtonExit()
    {
        HideAll();
        //todo: implement exit
    }
    
    //panel Start 
    public void PressStartButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelStart;
        panelChoosePlan.Show();
    }
    
    //panel panelChoosePlan
    public void GanzKoerperTrainingButton()
    {
        trainingsPlan = 1; 
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyExp;
        panelChooseModifyExp.Show();
    }
    
    public void RueckenUebungenButton()
    {
        trainingsPlan = 2; 
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyExp;
        panelChooseModifyExp.Show();
    }
    
    public void FreiesTrainingButton()
    {
        trainingsPlan = 0; 
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyExp;
        panelChooseModifyExp.Show();
    }
    
    // panelChooseModifyExp
    public void PanelChooseModifyExpOne()
    {
        trainingsExperience = 0;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyDuration;
        panelChooseModifyDuration.Show();
    }
    
    public void PanelChooseModifyExpTwo()
    {
        trainingsExperience = 1;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyDuration;
        panelChooseModifyDuration.Show();
    }
    
    public void PanelChooseModifyExpThree()
    {
        trainingsExperience = 2;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyDuration;
        panelChooseModifyDuration.Show();
    }
    
    //panelChooseModifyDuration
    public void PanelChooseModifyDurOne()
    {
        trainingsDuration = 3;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseStart;
        panelChooseStart.Show();
    }
    
    public void PanelChooseModifyDurTwo()
    {
        trainingsDuration = 6;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseStart;
        panelChooseStart.Show();
    }
    
    public void PanelChooseModifyDurThree()
    {
        trainingsDuration = 9;
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseStart;
        panelChooseStart.Show();
    }

    public void PanelChooseModifyDurBackButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyExp;
        panelChooseModifyExp.Show();
    }
    
    //panelChooseStart
    
    public void PanelChooseStartBackButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyDuration;
        panelChooseModifyDuration.Show();
    }
    
    public void PanelChooseStartStartButton()
    {
        HideAll();
        //implent hideMenu
    }
    
    //panelPauseMenu
    
    public void PanelPauseÜbersichtButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseStart;
        panelChooseStart.Show();
    }

    public void PanelSettingBackButton()
    {
        HideAll();
        if (_currentPanel == CurrentPanelEnum.PanelStart)
        {
            panelStart.Show();
        }
        if (_currentPanel == CurrentPanelEnum.PanelChoosePlan)
        {
            panelChoosePlan.Show();
        }
        if (_currentPanel == CurrentPanelEnum.PanelChooseModifyExp)
        {
            panelChooseModifyExp.Show();
        }
        if (_currentPanel == CurrentPanelEnum.PanelChooseModifyDuration)
        {
            panelChooseModifyDuration.Show();
        }
        if (_currentPanel == CurrentPanelEnum.PanelChooseStart)
        {
            panelChooseStart.Show();
        }
        if (_currentPanel == CurrentPanelEnum.PanelPauseMenu)
        {
            panelPauseMenu.Show();
        }
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