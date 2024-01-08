using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    private List<IPauseable> paused = new List<IPauseable>();

    public void SetPause(bool pause)
    {
        foreach (var p in paused)
        {
            p.IsPaused = pause;
        }
    }

    public void Register(IPauseable p)
    {
        paused.Add(p);
    }
}
