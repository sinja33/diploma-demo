using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.XR.CoreUtils;

public class PossessionDetector : MonoBehaviour
{
    
    public void PossessInteractable()
    {
        // Find the XR Origin in the scene
        XROrigin xrOrigin = FindFirstObjectByType<XROrigin>();
        if (xrOrigin == null)
        {
            Debug.LogWarning("XR Origin not found!");
            return;
        }

        GameObject hFigura = gameObject;
        Transform cameraTransform = xrOrigin.Camera.transform;
        xrOrigin.transform.position = transform.position;

        hFigura.SetActive(false);
    }
}