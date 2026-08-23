using TMPro;
using UnityEngine;

public class DamagePopup : MonoBehaviour
{
    [SerializeField] private TMP_Text damageText;
    [SerializeField] private float moveSpeed = 50f;
    [SerializeField] private float lifetime = 0.6f;

    private float remainingLifetime;

    public void Initialize(float damage)
    {
        damageText.text = $"-{damage:0}";
        remainingLifetime = lifetime;
    }

    private void Update()
    {
        transform.position += Vector3.up * moveSpeed * Time.deltaTime;

        remainingLifetime -= Time.deltaTime;

        if (remainingLifetime <= 0f)
        {
            Destroy(gameObject);
        }
    }
}