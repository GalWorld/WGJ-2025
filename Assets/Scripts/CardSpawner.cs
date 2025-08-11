using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;

public class CardSpawner : MonoBehaviour
{
    public List<GameObject> allCards; // Prefabs de las 12 cartas
    public Transform spawnParent;     // Donde aparecerán
    public int totalRounds = 4;
    public Animator animator;
    private int currentRound = 0;
    private List<GameObject> remainingCards;

    void Start()
    {
        // Copia del mazo para no modificar el original
        remainingCards = new List<GameObject>(allCards);
        //animator.SetTrigger("Cortinas");
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
                StartCoroutine(SceneLoader(SceneManager.GetActiveScene().name));
            }
            else if (playerStats.power >= 50)
            {
                Debug.Log("Final 2");
                StartCoroutine(SceneLoader(SceneManager.GetActiveScene().name));
            }
            else
            {
                Debug.Log("Final 3");
                StartCoroutine(SceneLoader(SceneManager.GetActiveScene().name));
            }
        }
        else
        {
            Debug.LogError("No se encontró PlayerStats para determinar el final.");
        }
    }

    public IEnumerator SceneLoader(string nameScene)
    {
        animator.SetTrigger("Cortinas");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nameScene);
    }


}


