using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : LevelElement
{
    private List<Material> _colorList;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        _colorList = GameManager.LevelManager.CurrentLevel.Data.correctColors;

        GameManager.EventManager.OnGameStart += BringTheCarsToLineOnStart;
        GameManager.EventManager.OnCarCall += BrýngTheCar;
        GameManager.EventManager.OnCarFinishPosition += IsLevelCompleted;
    }

    private void OnDestroy()
    {
        GameManager.EventManager.OnGameStart -= BringTheCarsToLineOnStart;
        GameManager.EventManager.OnCarCall -= BrýngTheCar;
        GameManager.EventManager.OnCarFinishPosition -= IsLevelCompleted;

    }

    private void BrýngTheCar(Material buttonColor)
    {
        for (int i = 0; i < _colorList.Count; i++)
        {
            if (_colorList[i].color == buttonColor.color)
            {
                if (i == 0)
                    BringTheCar(Level.View._leftSide2.position, CarState.BackRow, _colorList[i]);
                else
                    BringTheCar(Level.View._rightSide2.position, CarState.BackRow, _colorList[i]);
            }
        }

    }

    private void BringTheCarsToLineOnStart()
    {
        BringTheCar(Level.View._leftSide1.position, CarState.FrontRow, _colorList[0]);
        BringTheCar(Level.View._rightSide1.position, CarState.FrontRow, _colorList[1]);
        BringTheCar(Level.View._leftSide2.position, CarState.BackRow, _colorList[0]);
        BringTheCar(Level.View._rightSide2.position, CarState.BackRow, _colorList[1]);
    }

    private void BringTheCar(Vector3 insPosition, CarState carState, Material colorCar)
    {
        int randomValue = Random.Range(0, Level.Data.Cars.Length);
        CarMain currentCar = 
            Instantiate(Level.Data.Cars[randomValue], insPosition,
                Level.Data.Cars[randomValue].transform.localRotation, Level.View._carsParent);

        currentCar.Data.CarState = carState;
        currentCar.Data.ColorMaterial = colorCar;
        currentCar.Initialize(GameManager);
        currentCar.Controller.SetTheColor(colorCar);
    }
    public void IsLevelCompleted()
    {
        for (int i = 0; i < Level.View.targetPlaces.Length; i++)
        {
            if (!Level.View.targetPlaces[i].isFull)
            {
                break;
            }
            else if (i == Level.View.targetPlaces.Length - 1)
            {
                Level.Data.isLevelCompleted = true;
                Debug.Log("LEVEL COMPLETED !");
            }
        }
        
    }
}
