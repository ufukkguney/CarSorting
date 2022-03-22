using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : CustomBehaviour
{
    public LevelMain CurrentLevel;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        CurrentLevel.Initialize(gameManager);
    }
}
