using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

/// <summary>
///custom collision detection, disables raycast when near cylinders, plays warning sound, works for single and double controllers
/// </summary>

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

    /// <summary>
    ///Initialization of the cylinder and and audio
    /// </summary>
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        // cylinder = gameObject.GetComponent<CylinderScript>().gameObject;
        cylinder_radius = cylinder.transform.localScale.x / 2;
        cylinder_top = cylinder.transform.position.y + cylinder.transform.localScale.y ;
        cylinder_bottom = cylinder.transform.position.y - cylinder.transform.localScale.y ;

        // Color
        //Get the Renderer component from the new cube
        renderer = cylinder.GetComponent<Renderer>();
        
       
    }
    /// <summary>
    ///Handling of the controller
    /// </summary>
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

    /// <summary>
    ///Visual and audio feedback when one controller interacts with cylinder
    /// </summary>
    /// <param name="controller">controller to check</param>

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
            audioSource.Play();
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

    /// <summary>
    ///Stop playing of audio file
    /// </summary>
    private void stopAudio()
    {
        if (audioPlaying)
        {
            audioSource.Stop();
            audioPlaying = false;
        }
    }
    /// <summary>
    ///Visual and audio feedback when both controllers interact with cylinder
    /// </summary>
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
            audioSource.Play();
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
    /// <summary>
    ///CHeck if both controllers are inside the cylinder
    /// </summary>
    /// <param name="tolerance">tolerance</param>
    /// <returns> controllers are inside the cylinder</returns>
    bool bothControllersInCylinder(float tolerance)
    {
        return controllerInCyliner(left_controller, tolerance) && controllerInCyliner(right_controller, tolerance);
    }
    /// <summary>
    ///Computes the distance between controller and cylinder
    /// </summary>
    /// <param name="cylinder">cylinder</param>
    /// <param name="controller">controller</param>
    /// <returns> the distance between controller and cylinder</returns
    float GetDistanceOnHorizontalPlain(Vector3 cylinder, Vector3 controller)
    {
        controller.y = 0;
        cylinder.y = 0;
        return Vector3.Distance(controller, cylinder);
    }

    /// <summary>
    ///Checks if controller is inside the cylinder
    /// </summary>
    /// <param name="controller">controller</param>
    /// <param name="tolerance">tolerance</param>
    /// <returns>true if controller is inside the cylinder</returns
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
    /// <summary>
    ///Changes the color of the object
    /// </summary>
    ///<param name="color"></param>
    void changeColor(Color color)
    {
        color.a = 0.25f;
        //Call SetColor using the shader property name "_Color" and setting the color to red
        Debug.Log(renderer);
        renderer.material.SetColor("_Color", color);
    }
}
