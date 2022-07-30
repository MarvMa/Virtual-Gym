using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Saves variables which are accessible from different scenes
/// </summary>
public static class CrossSceneInfo1
{
    /// <summary>
    /// Id of the animation which is currently the exercise in the middle of the scene
    /// </summary>
    /// <value>contains the identifier of the Exercise class for example: bicep_curl </value>
    public static string animation_id { get; set; }

    /// <summary>
    /// List of the exercises which are in the current choosen plan
    /// </summary>
    public static List<String> exercisesAsStrings;
}
