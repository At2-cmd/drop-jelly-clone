using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using Zenject;

public class BlockEntity : MonoBehaviour
{

    [Inject] IBlockController _blockController;
    [SerializeField] private BlockMovement blockMovement;
    [SerializeField] private SubBlock subBlockPrefab;
    [SerializeField] private Transform modelTransform;
    private Pool _pool;
    private GridColumn _lastInteractedGridColumn;
    private bool _isDropped;
    public bool IsDropped => _isDropped;

    private List<Vector3> subBlockOffsets = new List<Vector3>();

    public void Initialize()
    {
        blockMovement.Initialize(this, transform);
        GenerateRandomSubBlocks();
        _blockController.AddSelfIntoBlocksList(this);
    }

    public void Despawn()
    {
        _isDropped = false;
        _blockController.RemoveSelfFromBlocksList(this);
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
        _isDropped = true;
        var emptySlot = _lastInteractedGridColumn.GetTopMostEmptySlot();
        if (emptySlot == null) return;
        blockMovement.enabled = false;
        emptySlot.SetGridStatus(true, this);
        transform.DOMove(emptySlot.transform.position, .5f).OnComplete(() =>
        {
            _blockController.CheckIfMatchOccurs();
        });
        _blockController.GenerateNewBlock();
    }

    public void CheckIfMatchOccurs()
    {
        Debug.Log("Checking if match occurs");
    }

    private void GenerateRandomSubBlocks()
    {
        var selectedConfig = BlockConfigurations.Configurations[UnityEngine.Random.Range(0, BlockConfigurations.Configurations.Count)];
        var positions = selectedConfig.Positions;
        var scales = selectedConfig.Scales;

        List<SubBlockColor> usedColors = new List<SubBlockColor>();

        for (int i = 0; i < positions.Count; i++)
        {
            var subBlock = Instantiate(subBlockPrefab, modelTransform);
            subBlock.transform.localPosition = positions[i];
            subBlock.transform.localScale = scales[i];

            SubBlockColor color;
            do
            {
                color = (SubBlockColor)UnityEngine.Random.Range(0, Enum.GetValues(typeof(SubBlockColor)).Length);
            } while (usedColors.Contains(color));

            subBlock.SetColor(color);
            usedColors.Add(color);

            subBlock.transform.localScale = Vector3.zero;
            subBlock.transform.DOScale(scales[i], 0.5f).SetEase(Ease.OutBounce);
        }
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
