using System.Collections.Generic;
using UnityEngine;

public class OreUI : MonoBehaviour
{
    [SerializeField] private OreInventory inventory;
    [SerializeField] private Transform container;
    [SerializeField] private OreUIEntry entryPrefab;
    [SerializeField] private OreData[] ores;

    private readonly Dictionary<OreData, OreUIEntry> entries = new();

    private void Start()
    {
        if (inventory == null)
            inventory = FindAnyObjectByType<OreInventory>();

        CreateEntries();

        if (inventory != null)
            inventory.OreChanged += OnOreChanged;

        RefreshAll();
    }

    private void OnDestroy()
    {
        if (inventory != null)
            inventory.OreChanged -= OnOreChanged;
    }

    private void CreateEntries()
    {
        foreach (OreData ore in ores)
        {
            if (ore == null || entries.ContainsKey(ore))
                continue;

            OreUIEntry entry = Instantiate(entryPrefab, container);

            entry.SetOreName(ore.OreName);
            entry.SetAmount(0);

            entries.Add(ore, entry);
        }
    }

    private void OnOreChanged(OreData ore)
    {
        if (ore == null)
            return;

        if (entries.TryGetValue(ore, out OreUIEntry entry))
        {
            entry.SetAmount(inventory.GetAmount(ore));
        }
    }

    private void RefreshAll()
    {
        if (inventory == null)
            return;

        foreach (OreData ore in ores)
        {
            if (ore == null)
                continue;

            if (entries.TryGetValue(ore, out OreUIEntry entry))
            {
                entry.SetAmount(inventory.GetAmount(ore));
            }
        }
    }
}