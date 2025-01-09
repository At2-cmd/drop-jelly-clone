using UnityEngine;

public class GridColumn : MonoBehaviour
{
    [SerializeField] GameObject selectedIndicatorObject;
    [SerializeField] GridUnit[] gridUnits;

    public void OnInteracted()
    {
        selectedIndicatorObject.SetActive(true);
    }

    public void OnDeinteracted()
    {
        selectedIndicatorObject.SetActive(false);
    }
}
