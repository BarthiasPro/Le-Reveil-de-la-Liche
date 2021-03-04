using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonMenu : MonoBehaviour
{
    public GameObject aide;
    public void Quitter()
    {
        Application.Quit();
    }

    public void Commencer()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void AfficherAide()
    {
        aide.SetActive(true);
    }

    public void CacherAide()
    {
        aide.SetActive(false);
    }
}
