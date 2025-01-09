using DG.Tweening;
using System;
using UnityEngine;
using Zenject;

public class BlockEntity : MonoBehaviour
{
    [Inject] IBlockController _blockController;
    [SerializeField] private BlockMovement blockMovement;
    private Pool _pool;
    private GridColumn _lastInteractedGridColumn;
    public void Initialize()
    {
        blockMovement.Initialize(this,transform);
    }

    public void Despawn()
    {
        _pool.Despawn(this);
    }

    private void SetPool(Pool pool)
    {
        _pool = pool;
    }

    private void SetPosition(Vector3 position)
    {
        transform.position = position;
    }

    public void SetLastInteractedGrid(GridColumn gridColumn)
    {
        _lastInteractedGridColumn = gridColumn;
    }

    public void TryMovingIntoSelectedColumn()
    {
        if (_lastInteractedGridColumn == null) return;
        var emptySlot = _lastInteractedGridColumn.GetTopMostEmptySlot();
        if (emptySlot == null) return;
        blockMovement.enabled = false;
        transform.DOMove(emptySlot.transform.position,.5f);
        emptySlot.SetGridStatus(true, this);
        _blockController.GenerateNewBlock();
    }

    public class Pool : MonoMemoryPool<Vector3, BlockEntity>
    {
        protected override void OnCreated(BlockEntity item)
        {
            base.OnCreated(item);
            item.SetPool(this);
            item.Initialize();
        }

        protected override void OnDespawned(BlockEntity item)
        {
            base.OnDespawned(item);
        }

        protected override void OnDestroyed(BlockEntity item)
        {
            base.OnDestroyed(item);
        }

        protected override void OnSpawned(BlockEntity item)
        {
            base.OnSpawned(item);
        }

        protected override void Reinitialize(Vector3 position, BlockEntity item)
        {
            base.Reinitialize(position, item);
            item.SetPosition(position);
        }
    }
}
