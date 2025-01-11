using System;
using UnityEngine;

public class GridAreaEntity : MonoBehaviour
{
    [SerializeField] private GridColumn[] gridColumns;
    [SerializeField] private Transform blockGenerationPoint;
    public Transform BlockGenerationPoint => blockGenerationPoint;

    public void Initialize()
    {
        foreach (var gridColumn in gridColumns)
        {
            gridColumn.Initialize();
        }
    }
}
