using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : LevelElement
{
    public float BarrierTime;
    public float MoveTime;
    public List<Material> correctColors;
    public CarMain[] Cars;

    [HideInInspector]
    public bool isLevelCompleted;

    
}
