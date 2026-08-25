using TMPro;
using UnityEngine;

public class OreUIEntry : MonoBehaviour
{
    [SerializeField] private TMP_Text oreNameText;
    [SerializeField] private TMP_Text amountText;

    public void SetOreName(string oreName)
    {
        oreNameText.text = oreName;
    }

    public void SetAmount(int amount)
    {
        amountText.text = amount.ToString();
    }
}