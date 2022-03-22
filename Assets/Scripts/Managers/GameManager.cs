using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : CustomBehaviour
{
    public EventManager EventManager;
    public LevelManager LevelManager;
    public InputManager InputManager;


    private void Awake()
    {
        EventManager.Initialize(this);
        LevelManager.Initialize(this);
        InputManager.Initialize(this);
    }

    private void Start()
    {
        EventManager.GameStarted();
    }
}
