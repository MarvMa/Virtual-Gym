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
    public GameObject podiumGameObject;
    public GameObject spotLight;
    private GameObject target;
    private GameObject[] podiums;
    private int positionIndex;

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

    public List<GameObject> spawn(List<String> trainingsPlan, int startIndex)
    {
        List<GameObject> allObjects = new List<GameObject>();

        target = GameObject.FindWithTag("MainCamera");

        podiums = new GameObject[podestPositions.Length];
        positionIndex = 0;
       
        for (var i = startIndex; i < 9; i++)
        {
            allObjects.AddRange(innerSpawn(trainingsPlan, i));
        }
        for (var i = 0; i < startIndex; i++)
        {
            allObjects.AddRange(innerSpawn(trainingsPlan, i));
        }
        allObjects.AddRange(podiums);
        return allObjects;
    }

    private List<GameObject> innerSpawn(List<String> trainingsPlan, int animationIndex)
    {
        List<GameObject> animations = new List<GameObject>();
        Vector3 position = podestPositions[positionIndex];
        // Spawn Podests
        podiums[positionIndex] = Instantiate(podiumGameObject, position, Quaternion.identity);
        // Spawn Spotlights
        GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
        light.transform.Rotate(90, 0, 0);

        // Spawn Animation
        GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/" + trainingsPlan[animationIndex]);

        Debug.Log(trainingsPlan[animationIndex]);
        GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);
        animations.Add(animation);
        // Make Animation Look towards Player
        var lookPos = target.transform.position - animation.transform.position;
        lookPos.y = 0;
        lookPos.z = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        Debug.Log("rotation " + rotation);
        animation.transform.rotation = rotation;

        positionIndex++;

        return animations;
    }
}