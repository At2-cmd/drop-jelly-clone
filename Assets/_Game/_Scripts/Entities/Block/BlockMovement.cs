using UnityEngine;
using Zenject;

public class BlockMovement : MonoBehaviour
{
    [Inject] IInputDataProvider _inputDataProvider;
    private BlockEntity _blockEntity;
    private Transform _blockTransform;
    

    public void Initialize(BlockEntity blockEntity, Transform blockTransform)
    {
        _blockEntity = blockEntity;
        _blockTransform = blockTransform;
    }
}
