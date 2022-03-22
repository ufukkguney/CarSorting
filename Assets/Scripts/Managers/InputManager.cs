using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : CustomBehaviour
{
    public Button RightButton, LeftButton;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        RightButton.Initialize(gameManager);
        LeftButton.Initialize(gameManager);
    }



}
