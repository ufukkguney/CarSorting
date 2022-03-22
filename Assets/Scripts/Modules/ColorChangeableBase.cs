using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangeableBase : CustomBehaviour
{
    [SerializeField] protected MeshRenderer mesh;
    [SerializeField] protected SpriteRenderer sprite;
    [SerializeField] private bool isRight;

    [HideInInspector]
    public Material colorMaterial;


    public override void Initialize(GameManager gameManager)
    {
        base.Initialize(gameManager);
        GameManager.EventManager.OnGameStart += SetColor;
    }
    protected void BaseDestroy()
    {
        GameManager.EventManager.OnGameStart -= SetColor;
    }

    private void SetColor()
    {
        if (mesh != null)
        {
            if (isRight)
            {
                SetColorToMeshRenderer(mesh, GameManager.LevelManager.CurrentLevel.Data.correctColors[1]);
            }
            else
            {
                SetColorToMeshRenderer(mesh, GameManager.LevelManager.CurrentLevel.Data.correctColors[0]);
            }
        }
        else
        {
            if (isRight)
            {
                SetColorToSpriteRenderer(sprite, GameManager.LevelManager.CurrentLevel.Data.correctColors[1]);
            }
            else
            {
                SetColorToSpriteRenderer(sprite, GameManager.LevelManager.CurrentLevel.Data.correctColors[0]);
            }
        }
        
    }

    private void SetColorToMeshRenderer(MeshRenderer currentMesh,Material colorMaterial)
    {
        Material[] materials = new Material[currentMesh.materials.Length];

        for (int i = 0; i < materials.Length; i++)
        {
            materials[i] = colorMaterial;
        }

        mesh.materials = materials;
    }
    private void SetColorToSpriteRenderer(SpriteRenderer targetSprite, Material currentMaterial)
    {
        targetSprite.material = currentMaterial;
        colorMaterial = currentMaterial;
    }
}
