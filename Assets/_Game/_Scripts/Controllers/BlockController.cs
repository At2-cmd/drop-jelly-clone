using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class BlockController : MonoBehaviour, IInitializable, IBlockController
{
    [Inject] BlockEntity.Pool _blockEntityPool;
    [Inject] IGridAreaDataProvider _gridAreaDataProvider;
    private List<BlockEntity> _currentBlockEntities = new List<BlockEntity>();
    private BlockEntity _nextUnplacedBlock;
    BlockEntity IBlockController.GetNextUnplacedBlock => _nextUnplacedBlock;

    public void Initialize()
    {
        GenerateNewBlock();
    }
    public void GenerateNewBlock()
    {
        _nextUnplacedBlock = _blockEntityPool.Spawn(_gridAreaDataProvider.NewBlockGenerationPosition);
    }

    public void CheckIfMatchOccurs()
    {
        foreach (var block in _currentBlockEntities)
        {
            if (!block.IsDropped) continue;
            block.CheckIfMatchOccurs();
        }
    }

    public void AddSelfIntoBlocksList(BlockEntity block)
    {
        if (_currentBlockEntities.Contains(block)) return;
        _currentBlockEntities.Add(block);
    }

    public void RemoveSelfFromBlocksList(BlockEntity block)
    {
        if (!_currentBlockEntities.Contains(block)) return;
        _currentBlockEntities.Remove(block);
    }
}
