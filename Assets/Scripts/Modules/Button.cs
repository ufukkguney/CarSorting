using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Button : ColorChangeableBase
{
    private bool isSendReady = true;
    [SerializeField] private Transform _upPos, _downPos;
    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);

    }
    private void OnDestroy()
    {
        base.BaseDestroy();
    }

    private void OnMouseDown()
    {
        if (isSendReady && !GameManager.LevelManager.CurrentLevel.Data.isLevelCompleted)
        {
            isSendReady = false;
            mesh.transform.DOMove(_downPos.position, LevelVariables.ButtonTime).OnComplete(() =>
            {
                mesh.transform.DOMove(_upPos.position, LevelVariables.ButtonTime).OnComplete(() =>
                {
                    Invoke("SetSendReady", LevelVariables.BarrierTime);
                });
            });

            GameManager.EventManager.CarCall(mesh.material);
        }
    }

    private void SetSendReady()
    {
        isSendReady = true;
    }
}
