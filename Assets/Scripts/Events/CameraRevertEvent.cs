using System.Collections;
using UnityEngine;

public class CameraRevertEvent : BaseEvent
{
    private Camera cam;
    public override string EventName => "Переворот экрана";
    public override float Duration => 10;
    private MonoBehaviour mono;

    public CameraRevertEvent(MonoBehaviour mono)
    {
        this.mono = mono;
    }

    public override void Activate()
    {
        cam = Camera.main;
        mono.StartCoroutine(RevertCam(true));
    }
    public override void Deactivate() 
    {
        mono.StartCoroutine(RevertCam(false));
    }

    private IEnumerator RevertCam(bool activate)
    {
        int angle = activate == true ? 180 : 0;

        while (Mathf.RoundToInt(cam.transform.eulerAngles.z) != angle)
        {
            cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y,
            Mathf.Lerp(cam.transform.eulerAngles.z, angle, Time.deltaTime * 5));

            yield return new WaitForEndOfFrame();
        }
        cam.transform.eulerAngles = new Vector3(cam.transform.eulerAngles.x, cam.transform.eulerAngles.y, angle);
    }
}
