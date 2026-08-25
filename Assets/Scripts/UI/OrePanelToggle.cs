using UnityEngine;

public class OrePanelToggle : MonoBehaviour
{
    [SerializeField] private GameObject orePanel;

    public void Toggle()
    {
        if (orePanel == null)
            return;

        orePanel.SetActive(!orePanel.activeSelf);
    }
}