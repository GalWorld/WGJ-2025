using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
     public GameObject panelCredits; 

    
    public void PlayButton(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void OpenCredits()
    {
        panelCredits.SetActive(true);
    }

    public void CloseCredits()
    {
        panelCredits.SetActive(false);
    }
}
