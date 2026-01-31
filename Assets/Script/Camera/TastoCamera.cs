using UnityEngine;

public class TastoCamera : MonoBehaviour
{
    public TriggerCamera triggerCamera;

    void OnMouseDown()
    {
        triggerCamera.Scatto();
    }
   
}

