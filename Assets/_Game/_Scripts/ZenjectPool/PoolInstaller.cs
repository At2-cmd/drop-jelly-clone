using UnityEngine;
using Zenject;

public class PoolInstaller : MonoInstaller
{
    [SerializeField] private BlockEntity blockEntity;
    public override void InstallBindings()
    {
        Container.BindMemoryPool<BlockEntity, BlockEntity.Pool>()
                .WithInitialSize(10)
                .ExpandByDoubling()
                .FromComponentInNewPrefab(blockEntity)
                .UnderTransformGroup("BlockEntitiesPool");
    }
}