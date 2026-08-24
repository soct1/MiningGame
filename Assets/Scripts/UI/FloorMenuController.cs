using UnityEngine;

public class FloorMenuController : MonoBehaviour
{
    [SerializeField] private GameObject floorMenu;
    [SerializeField] private FloorManager floorManager;

    public void OpenMenu()
    {
        floorMenu.SetActive(true);
    }

    public void CloseMenu()
    {
        floorMenu.SetActive(false);
    }

    public void SelectFloor(int floorIndex)
    {
        floorManager.ChangeFloor(floorIndex);
        CloseMenu();
    }
}