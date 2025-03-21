using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBlock : MonoBehaviour
{
    [SerializeField] private MeshRenderer meshRenderer;
    private SubBlockColor _color;
    public SubBlockColor SubBlockColor => _color;
    public void SetColor(SubBlockColor color)
    {
        _color = color;
        switch (color)
        {
            case SubBlockColor.Yellow:
                meshRenderer.material.color = Color.yellow;
                break;
            case SubBlockColor.Red:
                meshRenderer.material.color = Color.red;
                break;
            case SubBlockColor.Blue:
                meshRenderer.material.color = Color.blue;
                break;
            case SubBlockColor.Green:
                meshRenderer.material.color = Color.green;
                break;
            default:
                Debug.LogWarning("Unknown color specified. Setting default color to white.");
                meshRenderer.material.color = Color.white;
                break;
        }
    }

}
