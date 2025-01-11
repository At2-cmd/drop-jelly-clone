using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SubBlock : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private MeshRenderer meshRenderer;

    public void SetColor(SubBlockColor color)
    {
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
