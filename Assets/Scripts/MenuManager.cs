using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject menuPanel;
    [SerializeField] private GameObject menuRanking;

    public void Play()
    {
        SceneManager.LoadScene("Nivel 1");
    }

    public void ShowMain()
    {
        menuPanel.SetActive(true);
        menuRanking.SetActive(false);
    }

    public void ShowRanking()
    {
        menuPanel.SetActive(false);
        menuRanking.SetActive(true);
    }
}
