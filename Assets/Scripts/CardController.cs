using UnityEngine;

public class CardControllerScript : MonoBehaviour
{
    public string cardName;
    public string description;
    public CardEffect[] effects; 

    private PlayerStats playerStats;

    private void Awake()
    {
        // Busca automáticamente un objeto PlayerStats en la escena
        playerStats = FindFirstObjectByType<PlayerStats>();

        if (playerStats == null)
        {
            Debug.LogError("No se encontró un PlayerStats en la escena.");
        }
    }

    public void ApplyEffects()
    {
        foreach (CardEffect effect in effects)
        {
            switch (effect.type)
            {
                case CardEffect.EffectType.Life:
                    playerStats.life += effect.value;
                    break;

                case CardEffect.EffectType.Luck:
                    playerStats.luck += effect.value;
                    break;

                case CardEffect.EffectType.Power:
                    playerStats.power += effect.value;
                    break;
            }
        }
    }
}

