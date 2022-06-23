using DataHandler;
using Unity.VisualScripting;
using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    // Public Variables
    public GameObject podestGameObject;
    public GameObject spotLight;

    private Vector3[] podestPositions = new[]
    {
        new Vector3(10, 0.1f, 10),
        new Vector3(14, 0.1f, 0),
        new Vector3(10, 0.1f, -10),
        new Vector3(0, 0.1f, -14),
        new Vector3(-10, 0.1f, -10),
        new Vector3(-14, 0.1f, 0),
        new Vector3(-10, 0.1f, 10),
        new Vector3(0, 0.1f, 14),
    };

    void Start()
    {
        GameObject[] podests = spawnPodests();
        Exercise[] exercises = JsonHandler.getExercises();
        if (exercises != null)
        {
            foreach (var exercise in exercises)
            {
                Debug.Log("Exercise" + exercise);
            }
        }
        else
        {
            Debug.Log("exercises are empty");
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    GameObject[] spawnPodests()
    {
        GameObject[] podests = new GameObject[podestPositions.Length];
        int index = 0;
        foreach (var position in podestPositions)
        {
            podests[index] = Instantiate(podestGameObject, position, Quaternion.identity);
            GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
            GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/situps");
            Debug.Log(animationPrefab);
            GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z), Quaternion.identity);
            light.transform.Rotate(90, 0, 0);
            index++;
        }

        return podests;
    }
}