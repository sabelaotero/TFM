using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;

using UnityEngine;
using UnityEngine.XR.Hands;
using UnityEngine.XR.Management;

public class XRHandDisabler : MonoBehaviour
{
    void Start()
    {
        if (XRGeneralSettings.Instance == null || XRGeneralSettings.Instance.Manager == null || XRGeneralSettings.Instance.Manager.activeLoader == null)
        {
            Debug.Log("XRHandDisabler: XR Manager or Loader not found, skipping hand subsystem shutdown.");
            return;
        }

        var handSubsystem = XRGeneralSettings.Instance.Manager.activeLoader.GetLoadedSubsystem<XRHandSubsystem>();

        if (handSubsystem != null)
        {
            handSubsystem.Stop();
            Debug.Log("XRHandDisabler: XR Hand Subsystem stopped.");
        }
        else
        {
            Debug.Log("XRHandDisabler: No XR Hand Subsystem found to stop.");
        }
    }
}



