using UnityEngine;

public class EventManager : MonoBehaviour
{
    private CameraRevertEvent revertEvent;

    private void Start()
    {
        revertEvent = new CameraRevertEvent();

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            revertEvent.Activate();
        }
        else if (Input.GetKeyDown(KeyCode.E))
        {
            revertEvent.Deactivate();
        }
    }
}
