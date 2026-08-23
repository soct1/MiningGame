using UnityEngine;

public class Mine : MonoBehaviour
{
    [SerializeField] private MineData data;
    [SerializeField] private int resourceAmount = 1;
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

        if (DamagePopupSpawner.Instance != null)
        {
            DamagePopupSpawner.Instance.ShowDamage(
                transform.position,
                actualDamage
            );
        }

        if (currentHP <= 0f)
        {
            currentHP = 0f;
            DestroyMine();
        }
    }

    private void DestroyMine()
    {
        ResourceInventory inventory =
            FindAnyObjectByType<ResourceInventory>();

        if (inventory != null && data.Resource != null)
        {
            inventory.Add(data.Resource, resourceAmount);
        }

        Destroy(gameObject);
    }
}