using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlockController : MonoBehaviour, IInitializable, IBlockController
{
    [Inject] BlockEntity.Pool _blockEntityPool;
    [Inject] IGridAreaDataProvider _gridAreaDataProvider;
    public void Initialize()
    {
        GenerateNewBlock();
    }
    public void GenerateNewBlock()
    {
        _blockEntityPool.Spawn(_gridAreaDataProvider.NewBlockGenerationPosition);
    }
}
