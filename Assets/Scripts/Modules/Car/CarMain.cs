using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarMain : CustomBehaviour
{
    public CarData Data;
    public CarView View;
    public CarController Controller;

    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

        Controller.Car = this;
        View.Car = this;
        Data.Car = this;

        Controller.Initialize(gameManager);
        View.Initialize(gameManager);
    }

}
