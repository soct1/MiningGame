using UnityEngine;

[CreateAssetMenu(
    fileName = "BarData",
    menuName = "CultOfTheMine/Bar Data"
)]
public class BarData : ScriptableObject
{
    [Header("Identity")]
    [SerializeField] private string barName;

    [Header("Sell")]
    [SerializeField] private string sellCurrencyId = "gold";
    [SerializeField] private int sellValue = 10;

    public string BarName => barName;

    public string SellCurrencyId => sellCurrencyId;

    public int SellValue => sellValue;
}