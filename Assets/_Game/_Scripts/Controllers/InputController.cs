using UnityEngine;
using Zenject;

public class InputController : MonoBehaviour, IInitializable, IInputDataProvider
{
    public float HorizontalInput => Input.mousePosition.x;
    public bool IsPressing => Input.GetMouseButton(0);
    public void Initialize(){}
}
