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
        // Forzar la posición al centro, pero dejar la rotación libre
        cameraTransform.localPosition = Vector3.zero;
    }
}
