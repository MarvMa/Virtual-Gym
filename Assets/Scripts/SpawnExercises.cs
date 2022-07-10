using System;
using System.Collections.Generic;
using System.Linq;
using DataHandler;
using Newtonsoft.Json;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    // Public Variables
    public GameObject podestGameObject;
    public GameObject spotLight;

    private Vector3[] podestPositions = new[]
    {
        new Vector3(0, 0.1f, 0),
        new Vector3(10, 0.1f, 10),
        new Vector3(14, 0.1f, 0),
        new Vector3(10, 0.1f, -10),
        new Vector3(0, 0.1f, -14),
        new Vector3(-10, 0.1f, -10),
        new Vector3(-14, 0.1f, 0),
        new Vector3(-10, 0.1f, 10),
        new Vector3(0, 0.1f, 14),
    };



    /*  GameObject createExerciseObject(Exercise)
      {

      }*/

    public GameObject[] spawnPodests(List<String> trainingsPlan)
    {

        GameObject target = GameObject.FindWithTag("MainCamera");

        GameObject[] podests = new GameObject[podestPositions.Length];
        int index = 0;
       
        foreach (var exercise in trainingsPlan)
        {
            Vector3 position = podestPositions[index];
            // Spawn Podests
            podests[index] = Instantiate(podestGameObject, position, Quaternion.identity);
            // Spawn Spotlights
            GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
            light.transform.Rotate(90, 0, 0);

            // Spawn Animation
            GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/" + exercise);

            GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
                Quaternion.identity);
            // Make Animation Look towards Player
            var lookPos = target.transform.position - animation.transform.position;
            lookPos.y = 0;
            lookPos.z = 0;
            Quaternion rotation = Quaternion.LookRotation(lookPos);
            Debug.Log("rotation " + rotation);
            animation.transform.rotation = rotation;

            index++;
        }

        return podests;
    }
}