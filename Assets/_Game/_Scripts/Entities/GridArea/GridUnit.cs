using UnityEngine;

public class GridUnit : MonoBehaviour
{
    private bool _isFilled;
    private BlockEntity _userBlockEntity;
    public bool IsFilled => _isFilled;
    public BlockEntity UserBlockEntity => _userBlockEntity;

    public void SetGridStatus(bool isFilled, BlockEntity userBlock = null)
    {
        _isFilled = isFilled;
        _userBlockEntity = userBlock;
    }
}
