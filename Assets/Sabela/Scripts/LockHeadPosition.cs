using UnityEngine;
using UnityEngine.XR;

public class LockHeadPosition : MonoBehaviour
{
    public Transform cameraTransform;

    void Start()
    {
       // cameraTransform = GetComponent<Camera>().transform;
    }

    void LateUpdate()
    {
        // Forzar la posici�n al centro, pero dejar la rotaci�n libre
        cameraTransform.localPosition = Vector3.zero;
    }
}
