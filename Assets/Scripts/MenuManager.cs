using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using System.Threading.Tasks;
using DataHandler;
using System.Linq;

public class MenuManager : MonoBehaviour
{
    public GameObject uibBackground;

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

    private bool is_visible = true;
    private bool is_spawned = false;

    public SpawnExercises spawnExercises;
    private List<TrainingPlan> filteredTrainingsPlan;
    private List<InnerExercise> availableExercises;
    private List<String> exercisesAsStrings;




    private enum CurrentPanelEnum
    {
        PanelStart,
        PanelChoosePlan,
        PanelChooseModifyExp,
        PanelChooseModifyDuration,
        PanelChooseStart,
        PanelPauseMenu
    }


    private Boolean sethideMenu = false;
    private Boolean setShowMenu = false;


    private void Start()
    {
       
        spawnExercises = GameObject.FindWithTag("GameManager").GetComponent<SpawnExercises>();
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
    public void GKTrainingButton()
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
        sethideMenu = true;
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
        sethideMenu = true;
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

    private void FixedUpdate()
    {
        if (sethideMenu)
        {
            if (transform.position.y > -1.1f)
            {
                uibBackground.transform.Translate(0, -1.2f * Time.deltaTime, 0);
                transform.Translate(0, -1.2f * Time.deltaTime, 0);
                is_visible = false;
            }
        }
        if (setShowMenu)
        {
            if (transform.position.y < 1.684)
            {
                uibBackground.transform.Translate(0, 0.8f * Time.deltaTime, 0);
                transform.Translate(0, 0.5f * Time.deltaTime, 0);
            }
        }

        if (!is_visible && !is_spawned)
        {
            spawnScene();
            is_spawned = true;
        }

    }

    public List<String> ReturnTrainingPlan()
    {
        //Get both trainingsplans
        filteredTrainingsPlan = JsonHandler.getTrainingPlans();
        //Select the trainingplan and sort the exercises by descending difficulty
        availableExercises = filteredTrainingsPlan[trainingsPlan-1].exercises.OrderByDescending(o => o.exerciseDifficulty).ToList();
        foreach (var item in availableExercises)
        {
            //Remove exercises with not matching difficulty
            if(item.exerciseDifficulty > trainingsExperience)
            {
                availableExercises.Remove(item);
            }
        }
        //Select amount of exercises
        switch (trainingsDuration)
        {
            case 0:
                availableExercises.Take(3);
                break;

            case 1:
                availableExercises.Take(6);
                break;

            case 2:
                availableExercises.Take(9);
                break;
    
        }

        exercisesAsStrings = new List<string>();
        //Return only the string names of the exercises in a list
        foreach (var item in availableExercises)
        {
            
            exercisesAsStrings.Add(item.exerciseName);
        }
        Debug.Log(exercisesAsStrings.ToString());
        return exercisesAsStrings;

    }
    // async 
        void spawnScene()
    {

        // await Task.Delay(2500);
        spawnExercises.spawnPodests(ReturnTrainingPlan());

    }
}