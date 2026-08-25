using UnityEngine;

public class CurrencyUI : MonoBehaviour
{
    [SerializeField] private CurrencyInventory currencyInventory;

    [Header("Currencies")]
    [SerializeField] private string[] currencyIds;

    [Header("UI")]
    [SerializeField] private Transform container;
    [SerializeField] private CurrencyUIEntry entryPrefab;

    private void Start()
    {
        if (currencyInventory == null)
            currencyInventory =
                FindAnyObjectByType<CurrencyInventory>();

        CreateEntries();
    }

    private void CreateEntries()
    {
        if (container == null ||
            entryPrefab == null ||
            currencyInventory == null)
            return;

        foreach (string currencyId in currencyIds)
        {
            if (string.IsNullOrEmpty(currencyId))
                continue;

            CurrencyUIEntry entry =
                Instantiate(entryPrefab, container);

            entry.Initialize(
                currencyInventory,
                currencyId
            );
        }
    }
}