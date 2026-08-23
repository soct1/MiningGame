using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private MineData data;

    private float currentHP;

    public MineData Data => data;
    public float CurrentHP => currentHP;

    public void SetData(MineData newData)
    {
        data = newData;
        currentHP = data.MaxHP;
    }

    public void TakeDamage(float damage)
    {
        if (data == null)
            return;

        float actualDamage = damage / data.Hardness;

        currentHP -= actualDamage;

        if (currentHP <= 0f)
        {
            currentHP = 0f;
            DestroyMine();
        }
    }

    private void DestroyMine()
    {
        Destroy(gameObject);
    }
}