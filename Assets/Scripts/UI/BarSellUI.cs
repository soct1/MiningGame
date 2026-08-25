using UnityEngine;

public class BarSellUI : MonoBehaviour
{
    [SerializeField] private BarSellSystem sellSystem;
    [SerializeField] private BarInventory barInventory;

    [Header("Bars")]
    [SerializeField] private BarData[] bars;

    [Header("UI")]
    [SerializeField] private Transform container;
    [SerializeField] private BarSellUIEntry entryPrefab;

    private void Start()
    {
        if (sellSystem == null)
            sellSystem = FindAnyObjectByType<BarSellSystem>();

        if (barInventory == null)
            barInventory = FindAnyObjectByType<BarInventory>();

        CreateEntries();
    }

    private void CreateEntries()
    {
        if (container == null ||
            entryPrefab == null ||
            sellSystem == null ||
            barInventory == null)
            return;

        foreach (BarData bar in bars)
        {
            if (bar == null)
                continue;

            BarSellUIEntry entry =
                Instantiate(entryPrefab, container);

            entry.Initialize(
                sellSystem,
                barInventory,
                bar
            );
        }
    }
}