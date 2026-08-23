using UnityEngine;

public class DamagePopupSpawner : MonoBehaviour
{
    public static DamagePopupSpawner Instance { get; private set; }

    [SerializeField] private DamagePopup damagePopupPrefab;
    [SerializeField] private Transform popupContainer;
    [SerializeField] private Camera worldCamera;

    private void Awake()
    {
        Instance = this;
    }

    public void ShowDamage(Vector3 worldPosition, float damage)
    {
        Vector3 screenPosition =
            worldCamera.WorldToScreenPoint(worldPosition);

        DamagePopup popup =
            Instantiate(
                damagePopupPrefab,
                screenPosition,
                Quaternion.identity,
                popupContainer
            );

        popup.Initialize(damage);
    }
}