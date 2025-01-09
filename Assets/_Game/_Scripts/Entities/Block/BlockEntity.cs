using UnityEngine;
using Zenject;

public class BlockEntity : MonoBehaviour
{
    private Pool _pool;

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

    public class Pool : MonoMemoryPool<Vector3, BlockEntity>
    {
        protected override void OnCreated(BlockEntity item)
        {
            base.OnCreated(item);
            item.SetPool(this);
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
