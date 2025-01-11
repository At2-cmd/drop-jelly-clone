using System;
using System.Collections.Generic;
using UnityEngine;

public class GridUnit : MonoBehaviour
{
    private List<GridUnit> _neighbourGrids = new();
    private bool _isFilled;
    private BlockEntity _userBlockEntity;
    public bool IsFilled => _isFilled;
    public BlockEntity UserBlockEntity => _userBlockEntity;

    private static readonly Vector3[] Directions =
    {
        Vector3.forward,
        Vector3.back,
        Vector3.left,
        Vector3.right
    };

    public void Initialize()
    {
        FindNeighbourGrids();
    }

    public void FindNeighbourGrids()
    {
        _neighbourGrids.Clear();

        float rayDistance = 1.0f;
        foreach (var direction in Directions)
        {
            if (Physics.Raycast(transform.position, direction, out RaycastHit hit, rayDistance))
            {
                GridUnit neighbour = hit.collider.GetComponent<GridUnit>();
                if (neighbour != null)
                {
                    _neighbourGrids.Add(neighbour);
                }
            }
        }
    }

    public void SetGridStatus(bool isFilled, BlockEntity userBlock = null)
    {
        _isFilled = isFilled;
        _userBlockEntity = userBlock;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        float rayDistance = 1.0f;
        foreach (var direction in Directions)
        {
            Gizmos.DrawLine(transform.position, transform.position + direction * rayDistance);
        }
    }
}
