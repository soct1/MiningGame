using UnityEngine;
using UnityEngine.UI;

public class FloorMenuController : MonoBehaviour
{
    [SerializeField] private GameObject floorMenu;
    [SerializeField] private FloorManager floorManager;
    [SerializeField] private FloorProgression floorProgression;
    [SerializeField] private FloorNavigationUI floorNavigationUI;
    [Header("Floor Buttons")]
    [SerializeField] private Button[] floorButtons;

    private void Start()
    {
        if (floorManager == null)
            floorManager = FindAnyObjectByType<FloorManager>();

        if (floorProgression == null)
            floorProgression = FindAnyObjectByType<FloorProgression>();

        if (floorProgression != null)
            floorProgression.FloorUnlocked += OnFloorUnlocked;

        RefreshFloorButtons();

        if (floorMenu != null)
            floorMenu.SetActive(false);
    }

    private void OnDestroy()
    {
        if (floorProgression != null)
            floorProgression.FloorUnlocked -= OnFloorUnlocked;
    }

    public void OpenMenu()
    {
        RefreshFloorButtons();

        if (floorMenu != null)
            floorMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        if (floorMenu != null)
            floorMenu.SetActive(false);
    }

    public void SelectFloor(int floorIndex)
    {
        if (floorManager == null || floorProgression == null)
            return;

        if (!floorProgression.IsFloorUnlocked(floorIndex))
            return;

        if (floorNavigationUI != null)
            floorNavigationUI.DisableAutoFloor();

        floorManager.ChangeFloor(floorIndex);

        CloseMenu();
    }

    private void OnFloorUnlocked(int floorIndex)
    {
        RefreshFloorButtons();
    }

    private void RefreshFloorButtons()
    {
        if (floorButtons == null || floorProgression == null)
            return;

        for (int i = 0; i < floorButtons.Length; i++)
        {
            if (floorButtons[i] == null)
                continue;

            bool unlocked = floorProgression.IsFloorUnlocked(i);

            floorButtons[i].gameObject.SetActive(unlocked);
        }
    }
}