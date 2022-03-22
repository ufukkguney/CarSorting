using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CarState
{
    FrontRow,
    BackRow,
    OnTheRoad
}
public class CarData : CarElement
{
    public Material ColorMaterial;
    public float Speed;
    public CarState CarState;
}
