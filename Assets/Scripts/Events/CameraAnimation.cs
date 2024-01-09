using System.Collections;
using UnityEngine;

public class CameraAnimation : MonoBehaviour
{
    public void RevertCamera(bool activate)
    {
        IEnumerator coroutine = RevertCam(activate);
        StartCoroutine(coroutine);
    }

    private IEnumerator RevertCam(bool activate)
    {
        int angle = activate == true ? 180 : 0;

        while (Mathf.RoundToInt(transform.eulerAngles.z) != angle)
        {
            transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 
                Mathf.Lerp(transform.eulerAngles.z, angle, Time.deltaTime * 5));

            yield return new WaitForEndOfFrame();
        }
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, angle);
    }
}