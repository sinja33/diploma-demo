using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;



public class TeleportToObject : MonoBehaviour
{
    public UnityEngine.XR.Interaction.Toolkit.Interactors.XRRayInteractor rightRayInteractor;
    public Transform xrOrigin;
    public string targetTag = "possession";

    private InputDevice rightHandDevice;

    void Start()
    {
        List<InputDevice> devices = new List<InputDevice>();
        InputDevices.GetDevicesAtXRNode(XRNode.RightHand, devices);
        if (devices.Count > 0)
        {
            rightHandDevice = devices[0];
        }
    }

    void Update()
    {
        if (!rightHandDevice.isValid)
        {
            InputDevices.GetDevicesAtXRNode(XRNode.RightHand, new List<InputDevice> { rightHandDevice });
        }

        // Check if grip button is pressed
        if (rightHandDevice.TryGetFeatureValue(CommonUsages.gripButton, out bool isGripping) && isGripping)
        {
            // Check what the ray is hitting
            if (rightRayInteractor.TryGetCurrent3DRaycastHit(out RaycastHit hit))
            {
                if (hit.transform.CompareTag(targetTag))
                {
                    TeleportTo(hit.transform);
                }
            }
        }
    }

    void TeleportTo(Transform target)
    {
        // Offset the XR origin based on camera's current offset
        Transform cameraTransform = xrOrigin.GetComponentInChildren<Camera>().transform;

        Vector3 cameraOffset = xrOrigin.position - cameraTransform.position;
        Vector3 newOriginPosition = target.position + cameraOffset;

        xrOrigin.position = newOriginPosition;
        xrOrigin.rotation = target.rotation;
    }
}

