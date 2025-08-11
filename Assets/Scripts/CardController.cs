using UnityEngine;
using TMPro;

public class CardControllerScript : MonoBehaviour
{
    public string cardName;
    public string description;
    public CardEffect[] effects;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descriptionText;
    private PlayerStats playerStats;
    private CardSpawner cardSpawner;

    public void SetupCard(string name, string desc)
    {
        cardName = name;
        description = desc;

        if (nameText != null) nameText.text = name;
        if (descriptionText != null) descriptionText.text = desc;
    }

    private void Awake()
    {
        // Busca automáticamente un objeto PlayerStats en la escena
        playerStats = FindFirstObjectByType<PlayerStats>();

        cardSpawner = FindFirstObjectByType<CardSpawner>();

        if (playerStats == null)
        {
            Debug.LogError("No se encontró un PlayerStats en la escena.");
        }
    }

    public void ApplyEffects()
    {
        foreach (CardEffect effect in effects)
        {
            float finalValue = effect.value;

            // Si la carta es compleja, tiramos un "dado" 50/50
            if (effect.isComplex)
            {
                if (Random.value < 0.5f) // 50% de probabilidad
                {
                    finalValue = -finalValue; // Invierte el signo
                }
            }

            switch (effect.type)
            {
                case CardEffect.EffectType.Life:
                    playerStats.life += finalValue;
                    playerStats.life = Mathf.Clamp(playerStats.life, 0, 100);
                    break;

                case CardEffect.EffectType.Luck:
                    playerStats.luck += finalValue;
                    playerStats.luck = Mathf.Clamp(playerStats.luck, 0, 100);
                    break;

                case CardEffect.EffectType.Power:
                    playerStats.power += finalValue;
                    playerStats.power = Mathf.Clamp(playerStats.power, 0, 100);
                    break;
            }
        }
        cardSpawner.StartNextRound();
    }

    


}

