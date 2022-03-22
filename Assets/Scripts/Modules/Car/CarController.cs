using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;

public class CarController : CarElement
{
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnCarCall += SendTheCar;
    }
    private void OnDestroy()
    {
        GameManager.EventManager.OnCarCall -= SendTheCar;
    }

    public void SetTheColor(Material colorMaterial)
    {
        Car.View._body.material = colorMaterial;
    }

    public void SendTheCar(Material material)
    {
        if (Car.Data.CarState == CarState.FrontRow && Car.Data.ColorMaterial.color == material.color)
        {
            Car.Transform.DOMove(Car.transform.position + Vector3.forward * 100, GameManager.LevelManager.CurrentLevel.Data.MoveTime - 1).SetEase(Ease.InOutSine);
        }
        else if(Car.Data.CarState == CarState.BackRow && Car.Data.ColorMaterial.color == material.color)
        {
            Car.Data.CarState = CarState.FrontRow;
            Car.Transform.DOMove(Car.transform.position + Vector3.forward * 30, GameManager.LevelManager.CurrentLevel.Data.MoveTime - 1).SetEase(Ease.InOutSine);
        }
    }

    public void SendTheCarWithPath(Vector3[] path)
    {
        Car.Data.CarState = CarState.OnTheRoad;
        GameManager.EventManager.CarLastPosition();
        Car.Transform.DOPath(path, GameManager.LevelManager.CurrentLevel.Data.MoveTime, PathType.CatmullRom).SetLookAt(0.2f, Vector3.forward).OnComplete(() => 
        {
            Car.View.tick.gameObject.SetActive(true);
            Car.View.tick.transform.DOScale((Car.View.tick.transform.localScale + Vector3.one), .5f).OnComplete(() =>
             {
                 Car.View.tick.transform.DOScale((Car.View.tick.transform.localScale - Vector3.one), .5f);
             });
        });
    }

    public void CreatePathAndSendTheCar(int targetPlaceIndex, TargetPlace[] choosenRoad)
    {
        targetPlaceIndex++;

        Vector3[] currentPath = new Vector3[targetPlaceIndex];

        for (int i = 0; i < currentPath.Length; i++)
        {
            currentPath[i] = choosenRoad[i].transform.position;
        }
        Car.Controller.SendTheCarWithPath(currentPath);
    }
}
