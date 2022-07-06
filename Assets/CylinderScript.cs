using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR;

public class CylinderScript : MonoBehaviour
{
    
    public ActionBasedController xr;
    private GameObject cylinder;
 
    void Start()
    {
        cylinder = gameObject.GetComponent<CylinderScript>().gameObject;
        Debug.Log(cylinder.transform.position);
        Debug.Log("cylinder diameter: " + cylinder.transform.localScale.x);
        Debug.Log("cylinder diameter: " + cylinder.transform.localScale.y);
        Debug.Log("cylinder diameter: " + cylinder.transform.localScale.z);
        
        UnityEngine.XR.InputDevice device = InputDevices.GetDeviceAtXRNode(XRNode.RightHand);
        HapticCapabilities capabilities;
        Debug.Log(device);
        Debug.Log(device.TryGetHapticCapabilities(out capabilities));
        if (device.TryGetHapticCapabilities(out capabilities))
        {
            Debug.Log(capabilities.supportsImpulse);
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);
        }

        device = InputDevices.GetDeviceAtXRNode(XRNode.LeftHand);
        if (device.TryGetHapticCapabilities(out capabilities))
            if (capabilities.supportsImpulse)
                device.SendHapticImpulse(0, 0.5f, 1.0f);

        // wait();
        // xr = (XRController) GameObject.FindObjectOfType(typeof(XRController));
        // bool test = xr.SendHapticImpulse(0.7f, 2f);
        // Debug.Log("haptic: " + test);
        // Debug.Log(xr.hapticDeviceAction);
        // Debug.Log(xr.isActiveAndEnabled);
    }

    // IEnumerator wait()
    // {
    //     yield return new WaitForSeconds(7);
    // }
    // Start is called before the first frame update
    // void Start()
    // {
    //     var list = new List<ActionBasedController>(GetComponents<ActionBasedController>());
    //     ActionBasedController actionBasedController = list[0];
    //     //ActionBasedController actionBasedController = GetComponent<ActionBasedController>();
    //     Debug.Log(actionBasedController.isActiveAndEnabled);
    //     actionBasedController.SendHapticImpulse(0.1f, 1f);
    // }

    // Update is called once per frame
    void Update()
    {
        Vector3 controllerPosition = xr.modelParent.position;
        Vector3 cylinderPosition = cylinder.transform.position;
        controllerPosition.y = 0;
        cylinderPosition.y = 0;
        float distance = Vector3.Distance(controllerPosition, cylinderPosition);
        float height = 0.6f;
        if (distance < 0.15)
        {
            if (xr.modelParent.position.y < height)
            {
                Debug.Log(distance);
            }
        }
        
        // Debug.Log(xr.modelParent.position);
    }
}
