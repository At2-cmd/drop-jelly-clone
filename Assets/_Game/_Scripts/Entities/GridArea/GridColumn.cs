using UnityEngine;

public class GridColumn : MonoBehaviour
{
    [SerializeField] GameObject selectedIndicatorObject;
    [SerializeField] GridUnit[] gridUnits;

    public void Initialize()
    {
        foreach (var gridUnit in gridUnits)
        {
            gridUnit.Initialize();
        }
    }
    public void OnInteracted()
    {
        selectedIndicatorObject.SetActive(true);
    }

    public void OnDeinteracted()
    {
        selectedIndicatorObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.TryGetComponent(out BlockEntity block))
        {
            block.SetLastInteractedGrid(this);
            OnInteracted();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.transform.TryGetComponent(out BlockEntity block))
        {
            OnDeinteracted();
        }
    }

    public GridUnit GetTopMostEmptySlot()
    {
        foreach (var gridUnit in gridUnits)
        {
            if (gridUnit.IsFilled) continue;
            else
            {
                return gridUnit;
            }
        }
        Debug.Log("Column is Full! Fail.");
        return null;
    }
}
