using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Saves variables which are accessible from different scenes
/// </summary>
public static class CrossSceneInfo1
{
    public static string animation_id { get; set; }

    public static bool hasStarted { get; set; }

    public static List<GameObject> staticPodiumsAndAnimations;

    public static List<String> exercisesAsStrings;
}
