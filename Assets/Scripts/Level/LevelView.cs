using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelView : LevelElement
{
    public TargetPlace[] targetPlaces;
    public Barrier[] Barriers;
    public WayPoint[] wayPoints;


    public Transform _rightSide1, _rightSide2;
    public Transform _leftSide1, _leftSide2;
    public Transform _carsParent;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        for (int i = 0; i < targetPlaces.Length; i++)
        {
            targetPlaces[i].Initialize(gameManager);
        }
        for (int i = 0; i < Barriers.Length; i++)
        {
            Barriers[i].Initialize(gameManager);
        }
    }
}
