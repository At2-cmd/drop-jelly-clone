using UnityEngine;

public interface IInputDataProvider
{
    float HorizontalInput { get; }
    bool IsPressing { get; }
}
