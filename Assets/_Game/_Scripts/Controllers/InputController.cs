using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour, IInitializable, IInputDataProvider
{
    [Inject] IBlockController _blockController;
    [SerializeField] private float xBorder;
    public float HorizontalInput => Input.mousePosition.x;
    public bool IsPressing => Input.GetMouseButton(0);
    private Vector3 _currentMousePosition;
    private float _smoothSpeed = 10f;

    public void Initialize(){}

    public void Update()
    {
        if (IsPressing)
        {
            if (_blockController.GetNextUnplacedBlock == null) return;
            if (_blockController.GetNextUnplacedBlock.IsDropped) return;

            _currentMousePosition.x = HorizontalInput;
            _currentMousePosition.z = _blockController.GetNextUnplacedBlock.transform.position.z;

            Vector3 worldMousePosition = Camera.main.ScreenToWorldPoint(_currentMousePosition);
            
            // Clamp the x position within borders
            float clampedX = Mathf.Clamp(worldMousePosition.x, -xBorder, xBorder);
            Vector3 newPosition = new Vector3(clampedX, _blockController.GetNextUnplacedBlock.transform.position.y,
                _blockController.GetNextUnplacedBlock.transform.position.z);

            // Move smoothly to the new position
            _blockController.GetNextUnplacedBlock.transform.position = Vector3.Lerp(
                _blockController.GetNextUnplacedBlock.transform.position,
                newPosition,
                _smoothSpeed * Time.deltaTime);
        }
        else
        {
            _blockController.GetNextUnplacedBlock.TryMovingIntoSelectedColumn();
        }

    }
}
