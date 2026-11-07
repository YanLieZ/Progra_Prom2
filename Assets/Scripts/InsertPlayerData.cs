using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class InsertPlayerData : MonoBehaviour
{
    private const string url = "http://localhost/Progra_Flappy/insert_users.php";

    void Start()
    {
        
    }

    public void StartSendRequest()
    {
        StartCoroutine(SendRequest(GameDataManager.userName, GameDataManager.userHighscore, GameDataManager.userLastLevel, GameDataManager.userStatus));
    }

    public IEnumerator SendRequest(string user_name, int users_highscore, int users_lastlevel, string users_status)
    {
        WWWForm form = new WWWForm();
        form.AddField("user_name", user_name);
        form.AddField("users_highscore", users_highscore);
        form.AddField("users_lastlevel", users_lastlevel);
        form.AddField("users_status", users_status);

        using (UnityWebRequest www = UnityWebRequest.Post(url, form))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                Debug.Log("Se insertaron los datos del jugador con éxito");
            }
            else
            {
                Debug.Log("Error al ingresar los datos del jugador");
            }
        }
    }
}
