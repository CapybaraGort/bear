using UnityEngine;

public class CameraRevertEvent : BaseEvent
{
    private Camera cam;
    public override void Activate()
    {
        cam = Camera.main;
        cam.GetComponent<CameraAnimation>().RevertCamera(true);
    }

    public override void Deactivate() 
    {
        cam.GetComponent<CameraAnimation>().RevertCamera(false);
    }
}
