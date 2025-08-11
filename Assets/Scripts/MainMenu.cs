using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GameObject panelCredits;
    public Animator animator;


    public void PlayButton(string sceneName)
    {
        //SceneManager.LoadScene(sceneName);
        StartCoroutine(SceneLoader(sceneName));
    }

    public void OpenCredits()
    {
        panelCredits.SetActive(true);
    }

    public void CloseCredits()
    {
        panelCredits.SetActive(false);
    }

    public IEnumerator SceneLoader(string nameScene)
    {
        animator.SetTrigger("Cortinas");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(nameScene);
    }

    public void ReloadMusic()
    {
        MusicManager.Instance.PlayMainTheme();
    }
}
