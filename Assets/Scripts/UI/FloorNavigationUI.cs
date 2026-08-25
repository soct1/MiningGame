using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FloorNavigationUI : MonoBehaviour
{
    [SerializeField] private FloorManager floorManager;
    [SerializeField] private FloorProgression floorProgression;
    [SerializeField] private FloorMenuController floorMenuController;

    [Header("UI")]
    [SerializeField] private TMP_Text downButtonText;
    [SerializeField] private Button upButton;
    [SerializeField] private Button downButton;
    [SerializeField] private Button floorsButton;
    [SerializeField] private Button autoFloorButton;

    private bool autoFloorEnabled;

    private void Start()
    {
        if (floorManager == null)
            floorManager = FindAnyObjectByType<FloorManager>();

        if (floorProgression == null)
            floorProgression = FindAnyObjectByType<FloorProgression>();

        if (floorMenuController == null)
            floorMenuController = FindAnyObjectByType<FloorMenuController>();

        if (floorManager != null)
            floorManager.FloorChanged += Refresh;

        if (floorProgression != null)
        {
            floorProgression.FloorProgressChanged += OnFloorProgressChanged;
            floorProgression.FloorUnlocked += OnFloorUnlocked;
        }

        Refresh();
        UpdateAutoFloorButton();
    }

    private void OnDestroy()
    {
        if (floorManager != null)
            floorManager.FloorChanged -= Refresh;

        if (floorProgression != null)
        {
            floorProgression.FloorProgressChanged -= OnFloorProgressChanged;
            floorProgression.FloorUnlocked -= OnFloorUnlocked;
        }
    }

    public void GoUp()
    {
        if (autoFloorEnabled)
        {
            autoFloorEnabled = false;
            UpdateAutoFloorButton();
        }

        if (floorManager == null)
            return;

        int targetFloor = floorManager.ActiveFloorIndex - 1;

        if (targetFloor >= 0)
            floorManager.ChangeFloor(targetFloor);
    }

    public void GoDown()
    {
        if (floorManager == null || floorProgression == null)
            return;

        int targetFloor = floorManager.ActiveFloorIndex + 1;

        if (floorProgression.IsFloorUnlocked(targetFloor))
            floorManager.ChangeFloor(targetFloor);
    }

    public void OpenFloorsPanel()
    {
        if (floorMenuController != null)
            floorMenuController.OpenMenu();
    }

    public void ToggleAutoFloor()
    {
        autoFloorEnabled = !autoFloorEnabled;

        UpdateAutoFloorButton();
    }

    private void UpdateAutoFloorButton()
    {
        if (autoFloorButton == null)
            return;

        TMP_Text buttonText =
            autoFloorButton.GetComponentInChildren<TMP_Text>();

        if (buttonText != null)
        {
            buttonText.text = "AUTO";
        }

        Image buttonImage =
            autoFloorButton.GetComponent<Image>();

        if (buttonImage != null)
        {
            buttonImage.color = autoFloorEnabled
                ? new Color(0.3f, 0.8f, 0.3f)
                : new Color(0.6f, 0.6f, 0.6f);
        }
    }
    private void OnFloorProgressChanged(int floorIndex)
    {
        Refresh();
    }

    private void OnFloorUnlocked(int floorIndex)
    {
        Refresh();

        if (autoFloorEnabled)
            TryAutoAdvance();
    }

    private void TryAutoAdvance()
    {
        if (!autoFloorEnabled)
            return;

        if (floorManager == null || floorProgression == null)
            return;

        int currentFloor = floorManager.ActiveFloorIndex;
        int nextFloor = currentFloor + 1;

        if (nextFloor >= floorManager.FloorCount)
            return;

        if (!floorProgression.IsFloorUnlocked(nextFloor))
            return;

        floorManager.ChangeFloor(nextFloor);
    }

    private void Refresh(int ignored = 0)
    {
        if (floorManager == null || floorProgression == null)
            return;

        int currentFloor = floorManager.ActiveFloorIndex;

        // Upper floor
        bool canGoUp = currentFloor > 0;
        upButton.interactable = canGoUp;

        // Lower floor
        int lowerFloor = currentFloor + 1;

        if (lowerFloor < floorManager.FloorCount)
        {
            bool unlocked = floorProgression.IsFloorUnlocked(lowerFloor);

            downButton.interactable = unlocked;

            int completed =
                floorProgression.GetCompletedClears(currentFloor);

            int required =
                floorProgression.GetRequiredClears(currentFloor);

            if (unlocked)
            {
                downButtonText.text = "↓";
            }
            else
            {
                int remaining = required - completed;
                downButtonText.text = $"{remaining}";
            }
        }
        else
        {
            downButton.interactable = false;
            downButtonText.text = "↓";
        }
    }

    public void DisableAutoFloor()
    {
        if (!autoFloorEnabled)
            return;

        autoFloorEnabled = false;

        UpdateAutoFloorButton();
    }

}