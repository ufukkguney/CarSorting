using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarView : CarElement
{
    [HideInInspector]
    public TargetPlace currentTarget;

    public MeshRenderer _body;
    private bool isFindTheRoad;
    public SpriteRenderer tick;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.GetComponent<WayPoint>() != null)
        {
            int tempTargetPlaceIndex = 0;
            WayPoint currentPoint = other.transform.GetComponent<WayPoint>();

            for (int i = 0; i < currentPoint.AvailableTargetPlaces.Length; i++)
            {
                if (!currentPoint.AvailableTargetPlaces[i].isFull && _body.material.color == currentPoint.AvailableTargetPlaces[i].colorMaterial.color)
                {
                    currentTarget = currentPoint.AvailableTargetPlaces[i];
                }
            }

            for (int i = 0; i < currentPoint.MovementRoadFirst.Length; i++)
            {
                if (currentTarget == currentPoint.MovementRoadFirst[i] && !isFindTheRoad)
                {
                    isFindTheRoad = true;
                    currentPoint.MovementRoadFirst[i].isFull = true;
                    tempTargetPlaceIndex = i;
                    Car.Controller.CreatePathAndSendTheCar(tempTargetPlaceIndex, currentPoint.MovementRoadFirst);
                }
            }

            for (int i = 0; i < currentPoint.MovementRoadSecond.Length; i++)
            {
                if (currentTarget == currentPoint.MovementRoadSecond[i] && !isFindTheRoad)
                {
                    isFindTheRoad = true;
                    currentPoint.MovementRoadSecond[i].isFull = true;
                    tempTargetPlaceIndex = i;
                    Car.Controller.CreatePathAndSendTheCar(tempTargetPlaceIndex, currentPoint.MovementRoadSecond);
                }
            }
        }
        else if (other.transform.GetComponent<CarView>() != null && other.transform.GetComponent<CarView>().Car.Data.CarState == CarState.OnTheRoad)
        {
            Time.timeScale = 0;
            Debug.Log("FAILED !!");
        }
    }

}
