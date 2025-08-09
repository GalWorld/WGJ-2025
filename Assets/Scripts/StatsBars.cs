using UnityEngine;
using UnityEngine.UI;

public class StatBar : MonoBehaviour
{
    public Image fillImage; // La parte que se llena
    public PlayerStats playerStats;
    public StatType statToDisplay;
    public float lerpSpeed = 5f;
    private float targetFill;

    public enum StatType { Life, Luck, Power }

    void Update()
    {
        float currentValue = 0;
        float maxValue = 100f;

        switch (statToDisplay)
        {
            case StatType.Life:
                currentValue = playerStats.life;
                break;
            case StatType.Luck:
                currentValue = playerStats.luck;
                break;
            case StatType.Power:
                currentValue = playerStats.power;
                break;
        }

         // Calculamos el objetivo (0 a 1)
        targetFill = currentValue / maxValue;

        // Lerp para suavizar el cambio
        fillImage.fillAmount = Mathf.Lerp(fillImage.fillAmount, targetFill, Time.deltaTime * lerpSpeed);
    }
}

