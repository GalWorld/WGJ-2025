using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

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
                Debug.Log("Final 1");
            }
            else if (playerStats.power >= 50)
            {
                Debug.Log("Final 2");
            }
            else
            {
                Debug.Log("Final 3");
            }
        }
        else
        {
            Debug.LogError("No se encontró PlayerStats para determinar el final.");
        }
    }


}


