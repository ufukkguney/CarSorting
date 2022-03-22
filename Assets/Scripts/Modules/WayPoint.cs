using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : CustomBehaviour
{
    public TargetPlace[] AvailableTargetPlaces;
    public TargetPlace[] MovementRoadFirst, MovementRoadSecond;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

    }
}
