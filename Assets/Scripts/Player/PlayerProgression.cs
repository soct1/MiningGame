using System;
using UnityEngine;

public class PlayerProgression : MonoBehaviour
{
    [Header("Level")]
    [SerializeField] private int level = 1;

    [Header("Experience")]
    [SerializeField] private int currentExperience = 0;
    [SerializeField] private int baseExperience = 100;
    [SerializeField] private float experienceGrowth = 1.2f;

    public int Level => level;
    public int CurrentExperience => currentExperience;
    public int RequiredExperience => GetRequiredExperience(level);

    public event Action<int> LevelChanged;
    public event Action<int, int> ExperienceChanged;

    public void AddExperience(int amount)
    {
        if (amount <= 0)
            return;

        currentExperience += amount;

        while (currentExperience >= RequiredExperience)
        {
            currentExperience -= RequiredExperience;
            level++;

            LevelChanged?.Invoke(level);
        }

        ExperienceChanged?.Invoke(
            currentExperience,
            RequiredExperience
        );
    }

    private int GetRequiredExperience(int targetLevel)
    {
        return Mathf.RoundToInt(
            baseExperience * Mathf.Pow(experienceGrowth, targetLevel - 1)
        );
    }
}