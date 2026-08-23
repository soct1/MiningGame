using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private MineData data;

    public MineData Data => data;

    public void SetData(MineData newData)
    {
        data = newData;
    }
}