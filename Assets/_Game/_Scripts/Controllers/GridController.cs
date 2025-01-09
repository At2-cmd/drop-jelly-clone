using UnityEngine;
using Zenject;

public class GridController : MonoBehaviour, IInitializable, IGridAreaDataProvider
{
    [SerializeField] private GridAreaEntity gridAreaEntity;
    public Vector3 NewBlockGenerationPosition => gridAreaEntity.BlockGenerationPoint.position;

    public void Initialize()
    {

    }
}
