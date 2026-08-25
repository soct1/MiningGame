using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerProgressionUI : MonoBehaviour
{
    [SerializeField] private PlayerProgression progression;

    [Header("UI")]
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private TMP_Text experienceText;
    [SerializeField] private Slider experienceSlider;

    private void Start()
    {
        if (progression == null)
            progression = FindAnyObjectByType<PlayerProgression>();

        if (progression == null)
            return;

        progression.LevelChanged += OnLevelChanged;
        progression.ExperienceChanged += OnExperienceChanged;

        Refresh();
    }

    private void OnDestroy()
    {
        if (progression == null)
            return;

        progression.LevelChanged -= OnLevelChanged;
        progression.ExperienceChanged -= OnExperienceChanged;
    }

    private void OnLevelChanged(int level)
    {
        Refresh();
    }

    private void OnExperienceChanged(int current, int required)
    {
        UpdateExperience(current, required);
    }

    private void Refresh()
    {
        levelText.text = $"LEVEL {progression.Level}";
        UpdateExperience(
            progression.CurrentExperience,
            progression.RequiredExperience
        );
    }

    private void UpdateExperience(int current, int required)
    {
        experienceText.text = $"{current} / {required}";

        if (required > 0)
            experienceSlider.value = (float)current / required;
        else
            experienceSlider.value = 0f;
    }
}