using TMPro;
using Unity.VectorGraphics;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SubmitName : MonoBehaviour
{
    [SerializeField] private TMP_InputField username;
    [SerializeField] private InsertPlayerData insert;


    public void SaveNameToGameData()
    {
        if(username != null)
        {
            string user_name = username.text;

            if (string.IsNullOrWhiteSpace(user_name))
            {
                GameDataManager.userName = "AAA";
            }
            else
            {
                GameDataManager.userName = user_name.Trim();
            }

            insert.StartSendRequest();
            SceneManager.LoadScene("Menu Principal");
            Time.timeScale = 1;
        }

    }
}
