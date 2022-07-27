using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using DataHandler;
using UnityEngine;
using UnityEngine.Serialization;

/// <summary>
///  Class which contains the Logic for the Menu
/// </summary>
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

    public GameObject menuText;

    public GameObject menuBeenden;

    public GameObject menuSettings;

    public GameObject dividerHorizontal;

    private int trainingsPlan;

    private int trainingsExperience;

    private int trainingsDuration;

    private CurrentPanelEnum _currentPanel;

    private bool is_visible = true;

    private bool is_spawned = false;

    private bool menu_is_visible = true;

    public SpawnExercises spawnExercises;

    public MenuInPodiumActivator menuInPodiumActivator;

    private List<TrainingPlan> filteredTrainingsPlan;

    private List<InnerExercise> availableExercises;

    private List<String> exercisesAsStrings;

    private List<InnerExercise> helper;

    private int arrowCounter = 0;

    private List<GameObject> podiumsAndAnimations;

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

    private Boolean is_returnedToState = true;

    /// <summary>
    /// spawn menu
    /// </summary>
    private void Start()
    {
        spawnExercises =
            GameObject
                .FindWithTag("GameManager")
                .GetComponent<SpawnExercises>();
        menuInPodiumActivator =
            GameObject
                .FindWithTag("GameManager")
                .GetComponent<MenuInPodiumActivator>();
        HideAll();

        _currentPanel = CurrentPanelEnum.PanelStart;
        panelStart.Show();
    }


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

    public void PressStartButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelStart;
        panelChoosePlan.Show();
    }

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
        trainingsDuration = 8;
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

    public void PanelChooseStartBackButton()
    {
        HideAll();
        _currentPanel = CurrentPanelEnum.PanelChooseModifyDuration;
        panelChooseModifyDuration.Show();
    }

    public void PanelChooseStartStartButton()
    {
        ToggleMenuVisibility();
        menuInPodiumActivator.SetMenuActive();
        spawnScene();
    }

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

    private void ShowAll()
    {
        panelStart.Show();
        panelChoosePlan.Show();
        panelChooseModifyExp.Show();
        panelChooseModifyDuration.Show();
        panelChooseStart.Show();
        panelSettings.Show();
        panelPauseMenu.Show();
    }

     /// <summary>
     /// upper menu not hidden in HideAll()
     /// </summary>
    private void HideUpperMenu()
    {
        menuText.SetActive(false);
        menuSettings.SetActive(false);
        menuBeenden.SetActive(false);
        dividerHorizontal.SetActive(false);
    }

    private void ShowUpperMenu()
    {
        menuText.SetActive(true);
        menuSettings.SetActive(true);
        menuBeenden.SetActive(true);
        dividerHorizontal.SetActive(true);
    }

    public void ToggleMenuVisibility()
    {
        if (menu_is_visible)
        {
            HideAll();
            HideUpperMenu();
            uibBackground.SetActive(false);
            menu_is_visible = false;
            is_visible = false;
        }
        else
        {
            uibBackground.SetActive(true);
            ShowUpperMenu();
            panelStart.Show();
            menu_is_visible = true;
        }
    }

    /// <summary>
    /// returns list of exercises based on exercises in chosen training plan, optimised for chosen length and difficulty
    /// </summary>
    /// <returns>returns list of exercises</returns>
    public List<String> ReturnTrainingPlan()
    {
        /// Get both trainingsplans
        filteredTrainingsPlan = JsonHandler.getTrainingPlans();

        /// Select the trainingplan and sort the exercises by descending difficulty
        switch (trainingsExperience)
        {
            case 0:
                //0-1-2
                availableExercises =
                    filteredTrainingsPlan[trainingsPlan - 1]
                        .exercises
                        .OrderBy(o => o.exerciseDifficulty)
                        .ToList();
                break;
            /// <summary>
            /// 1-0-2 kind of unnessesary because there will always be 9 elements with difficulty 1 and 0 and 2 will never be included
            /// </summary>
            case 1:
                availableExercises =
                    filteredTrainingsPlan[trainingsPlan - 1]
                        .exercises
                        .OrderByDescending(o => o.exerciseDifficulty)
                        .ToList();
                helper =
                    availableExercises
                        .Where(o => o.exerciseDifficulty == 2)
                        .ToList();
                availableExercises = availableExercises.Except(helper).ToList();
                availableExercises.AddRange (helper);
                break;
            //2-1-0
            case 2:
                availableExercises =
                    filteredTrainingsPlan[trainingsPlan - 1]
                        .exercises
                        .OrderByDescending(o => o.exerciseDifficulty)
                        .ToList();
                break;
        }

        /// Select amount of exercises
        switch (trainingsDuration)
        {
            case 3:
                availableExercises = availableExercises.Take(3).ToList();
                break;
            case 6:
                availableExercises = availableExercises.Take(6).ToList();
                break;
            case 8:
                availableExercises = availableExercises.Take(8).ToList();
                break;
        }

        exercisesAsStrings = new List<String>();

        /// Return only the string names of the exercises in a list
        foreach (var item in availableExercises)
        {
            exercisesAsStrings.Add(item.exerciseName);
        }
        return exercisesAsStrings;
    }

    /// <summary>
    /// destroys podiums and animations if necessary, and spawns new ones based on new training plan
    /// </summary>
    void spawnScene()
    {
        if (podiumsAndAnimations != null && podiumsAndAnimations.Count != 0)
        {
            foreach (var exerciseContainer in podiumsAndAnimations)
            {
                Destroy (exerciseContainer);
            }
        }
        podiumsAndAnimations =
            spawnExercises.spawnPodiums(ReturnTrainingPlan());
    }

    public void SetShowMenuTrue()
    {
        setShowMenu = true;
    }
}
