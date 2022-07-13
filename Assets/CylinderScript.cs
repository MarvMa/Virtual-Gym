using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CylinderScript : MonoBehaviour
{
    
    public ActionBasedController left_controller;
    public ActionBasedController right_controller;
    public XRRayInteractor right_rayInteractor;
    public XRRayInteractor left_rayInteractor;
    public GameObject cylinder;
    private Renderer renderer;
    private float cylinder_radius;
    private float cylinder_top;
    private float cylinder_bottom;

    
    private AudioSource audioSource;
    private bool audioPlaying = false;
 
    void Start()
    {
        //audioSource = GetComponent<AudioSource>();
        // cylinder = gameObject.GetComponent<CylinderScript>().gameObject;
        cylinder_radius = cylinder.transform.localScale.x / 2;
        cylinder_top = cylinder.transform.position.y + cylinder.transform.localScale.y ;
        cylinder_bottom = cylinder.transform.position.y - cylinder.transform.localScale.y ;

        // Color
        //Get the Renderer component from the new cube
        renderer = cylinder.GetComponent<Renderer>();
        
       
    }
    void Update()
    {
        if (right_controller != null && left_controller == null)
        {
            handleSingleController(right_controller);
        } else if (right_controller == null && left_controller != null)
        {
            handleSingleController(left_controller);
        }
        else
        {
            handleBothControllers();
        }
    }

    private void handleSingleController(ActionBasedController controller)
    {
        if (controllerInCyliner(controller, 0.0f))
        {
            // Debug.Log(distance);
            changeColor(Color.green);
            // stopAudio();

        }
        else if (controllerInCyliner(controller, 0.3f))
        {
            changeColor(Color.yellow);
            //audioSource.Play();
            // audioPlaying = true;
        }
        else
        {
            changeColor(Color.red);
            // stopAudio();
        }

        if (controllerInCyliner(controller, 2.0f))
        {
            if (right_rayInteractor != null)
                right_rayInteractor.enabled = false;
            if (left_rayInteractor != null)
                left_rayInteractor.enabled = false;
        }
        else
        {
            if (right_rayInteractor != null)
                right_rayInteractor.enabled = true;
            if (left_rayInteractor != null)
                left_rayInteractor.enabled = true;
        }
    }

    private void stopAudio()
    {
        if (audioPlaying)
        {
            audioSource.Stop();
            audioPlaying = false;
        }
    }

    private void handleBothControllers()
    {
        if (bothControllersInCylinder(0.0f))
        {
            // Debug.Log(distance);
            changeColor(Color.green);
        }
        else if (bothControllersInCylinder(0.3f))
        {
            changeColor(Color.yellow);
        }
        else
        {
            changeColor(Color.red);
        }

        if (bothControllersInCylinder(2.0f))
        {
            right_rayInteractor.enabled = false;
            left_rayInteractor.enabled = false;
        }
        else
        {
            right_rayInteractor.enabled = true;
            left_rayInteractor.enabled = true;
        }
    }

    bool bothControllersInCylinder(float tolerance)
    {
        return controllerInCyliner(left_controller, tolerance) && controllerInCyliner(right_controller, tolerance);
    }

    float GetDistanceOnHorizontalPlain(Vector3 cylinder, Vector3 controller)
    {
        controller.y = 0;
        cylinder.y = 0;
        return Vector3.Distance(controller, cylinder);
    }


    bool controllerInCyliner(ActionBasedController controller, float tolerance)
    {
        float controller_height = controller.modelParent.position.y;
        float controller_distance =
            GetDistanceOnHorizontalPlain(cylinder.transform.position, controller.modelParent.position);
        
        bool in_radius = controller_distance < (cylinder_radius + cylinder_radius*tolerance);
        bool below_top =controller_height < cylinder_top;
        bool above_bottom = controller_height > cylinder_bottom;
        return in_radius && below_top && above_bottom;
    }

    void changeColor(Color color)
    {
        color.a = 0.25f;
        //Call SetColor using the shader property name "_Color" and setting the color to red
        Debug.Log(renderer);
        renderer.material.SetColor("_Color", color);
    }
}
