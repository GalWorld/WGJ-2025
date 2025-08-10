using UnityEngine;
using System.Collections.Generic;

public class CardSpawner : MonoBehaviour
{
    public List<GameObject> allCards; // Prefabs de las 12 cartas
    public Transform spawnParent;     // Donde aparecerán
    public int totalRounds = 4;
    private int currentRound = 0;
    private List<GameObject> remainingCards;

    void Start()
    {
        // Copia del mazo para no modificar el original
        remainingCards = new List<GameObject>(allCards);
        StartNextRound();
    }

    public void StartNextRound()
    {
        if (currentRound >= totalRounds)
        {
            Debug.Log("Fin de la partida");
            EndGame();
            return;
        }

        currentRound++;
        Debug.Log("Ronda " + currentRound);
        SpawnRandomCards();
    }

    void SpawnRandomCards()
    {
        // Limpia cartas previas
        foreach (Transform child in spawnParent)
        {
            Destroy(child.gameObject);
        }

        // Elige 3 cartas aleatorias sin repetición
        for (int i = 0; i < 3; i++)
        {
            if (remainingCards.Count == 0) break;

            int randomIndex = Random.Range(0, remainingCards.Count);
            GameObject cardPrefab = remainingCards[randomIndex];

            Instantiate(cardPrefab, spawnParent);

            remainingCards.RemoveAt(randomIndex);
        }
    }

    private void EndGame()
    {
        PlayerStats playerStats = FindFirstObjectByType<PlayerStats>();

        if (playerStats != null)
        {
            if (playerStats.power >= 80)
            {
                Debug.Log("Final Épico: Te convertiste en la bruja suprema.");
            }
            else if (playerStats.power >= 50)
            {
                Debug.Log("Final Bueno: Superaste la prueba, pero con esfuerzo.");
            }
            else
            {
                Debug.Log("Final Malo: No lograste superar la prueba.");
            }
        }
        else
        {
            Debug.LogError("No se encontró PlayerStats para determinar el final.");
        }
    }


}


