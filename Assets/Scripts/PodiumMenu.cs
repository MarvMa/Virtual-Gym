using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PodiumScript : MonoBehaviour
{
    public SpawnExercises spawnExercises;

    private int arrowActivation = 0; 
    // Start is called before the first frame update
    void Start()
    {
        spawnExercises = GameObject.FindWithTag("GameManager").GetComponent<SpawnExercises>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void goLeft()
    {
        
    }
    
    public void goRight()
    {
        arrowActivation++;
    }
}
