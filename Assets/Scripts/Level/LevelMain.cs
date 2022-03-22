using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMain : CustomBehaviour
{
    public LevelData Data;
    public LevelView View;
    public LevelController Controller;


    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        Data.Level = this;
        View.Level = this;
        Controller.Level = this;

        View.Initialize(gameManager);
        Controller.Initialize(gameManager);
    }
}
