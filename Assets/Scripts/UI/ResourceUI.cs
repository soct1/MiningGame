using TMPro;
using UnityEngine;

public class ResourceUI : MonoBehaviour
{
    [SerializeField] private ResourceInventory inventory;

    [SerializeField] private ResourceData stoneResource;
    [SerializeField] private ResourceData coalResource;

    [SerializeField] private TMP_Text stoneText;
    [SerializeField] private TMP_Text coalText;

    private void Update()
    {
        if (inventory == null)
            return;

        stoneText.text =
            $"Stone: {inventory.GetAmount(stoneResource)}";

        coalText.text =
            $"Coal: {inventory.GetAmount(coalResource)}";
    }
}