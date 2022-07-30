using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SquatCylinderScript : MonoBehaviour
{
    public ActionBasedController left_controller;
    public ActionBasedController right_controller;
    public XRRayInteractor right_rayInteractor;
    public XRRayInteractor left_rayInteractor;
    private GameObject cylinder;
    private Renderer renderer;
    private float cylinder_radius;
    private float cylinder_top;
    private float cylinder_bottom;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
