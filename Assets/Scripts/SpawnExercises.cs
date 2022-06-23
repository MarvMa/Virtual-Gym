using UnityEngine;

public class SpawnExercises : MonoBehaviour
{
    public GameObject podestGameObject;

    public Vector3[] podestPositions = new[]
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
        GameObject[] podests= spawnPodests();
        Debug.Log(podests);
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
            podests[index] =  Instantiate(podestGameObject, position, Quaternion.identity);
            index++;
        }

        return podests;
    }
}