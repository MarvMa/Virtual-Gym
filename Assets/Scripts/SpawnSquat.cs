using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Used to spawn the squat exercise but not needed anymore
/// </summary>
public class SpawnSquat : MonoBehaviour
{
    // Public Variables
    public GameObject podestGameObject;
    public GameObject spotLight;

    private Vector3 position = new Vector3(0, 0.1f, 0);
    // Start is called before the first frame update
    void Start()
    {
        GameObject target = GameObject.FindWithTag("MainCamera");
        GameObject podest = Instantiate(podestGameObject, position, Quaternion.identity);
        GameObject light = Instantiate(spotLight, new Vector3(position.x, 5, position.z), Quaternion.identity);
        light.transform.Rotate(90, 0, 0);
        GameObject animationPrefab = Resources.Load<GameObject>("Prefabs/" + "back_squat");
            
        GameObject animation = Instantiate(animationPrefab, new Vector3(position.x, 0.18f, position.z),
            Quaternion.identity);
        
        // Make Animation Look towards Player
        var lookPos = target.transform.position - animation.transform.position;
        lookPos.y = 0;
        lookPos.z = 0;
        Quaternion rotation = Quaternion.LookRotation(lookPos);
        Debug.Log("rotation " + rotation);
        animation.transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
