using UnityEngine;
using Zenject;

public class BlockMovement : MonoBehaviour
{
    [Inject] IInputDataProvider _inputDataProvider;
    private BlockEntity _blockEntity;
    private Transform _blockTransform;
    private float _smoothSpeed = 10f;
    private Vector3 _currentMousePosition;

    public void Initialize(BlockEntity blockEntity, Transform blockTransform)
    {
        _blockEntity = blockEntity;
        _blockTransform = blockTransform;
    }

    public void Update()
    {
        if (_inputDataProvider.IsPressing)
        {
            _currentMousePosition.x = _inputDataProvider.HorizontalInput;
            _currentMousePosition.z = _blockTransform.position.z;
            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_currentMousePosition);
            Vector3 newPosition = new Vector3(worldMousePosition.x, _blockTransform.position.y, _blockTransform.position.z);
            _blockTransform.position = Vector3.Lerp(_blockTransform.position, newPosition, _smoothSpeed * Time.deltaTime);
        }
        else
        {
            _blockEntity.TryMovingIntoSelectedColumn();
        }
    }
}
