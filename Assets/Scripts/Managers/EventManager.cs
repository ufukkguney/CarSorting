using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class EventManager : CustomBehaviour
{
    public event Action OnGameStart;
    public event Action<Material> OnCarCall;
    public event Action OnCarFinishPosition;

    public void GameStarted()
    {
        OnGameStart?.Invoke();
    }

    public void CarCall(Material material)
    {
        OnCarCall?.Invoke(material);
    }

    public void CarLastPosition()
    {
        OnCarFinishPosition?.Invoke();
    }
}
