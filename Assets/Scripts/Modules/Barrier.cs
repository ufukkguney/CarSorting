using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Barrier : ColorChangeableBase
{
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnCarCall += OpenTheBarrier;
    }
    private void OnDestroy()
    {
        base.BaseDestroy();

        GameManager.EventManager.OnCarCall -= OpenTheBarrier;
    }

    private void OpenTheBarrier(Material callingMaterial)
    {
        if (mesh.material.color == callingMaterial.color)
        {
            transform.DORotate(new Vector3(0, 0, -90), GameManager.LevelManager.CurrentLevel.Data.BarrierTime).OnComplete(() =>
            {
                transform.DORotate(new Vector3(0, 0, 0), GameManager.LevelManager.CurrentLevel.Data.BarrierTime);
            });
        }
    }
}

    
