using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class UsersModel
{
    public int users_id;
    public string user_name;
    public int users_highscore;
    public int users_lastlevel;
    public string users_status;
}

[Serializable]
public class UsersArrayModel
{

    public UsersModel[] data;

}

public class RankingScript : MonoBehaviour
{
    private const string url = "http://localhost/Progra_Flappy/show_ranking.php";
    [SerializeField] private UsersArrayModel usersArrayModel;

    [SerializeField] private Transform content;
    [SerializeField] private GameObject row;
    public void Request()
    {
        StartCoroutine(SendRequest());
    }

    IEnumerator SendRequest()
    {
        using (UnityWebRequest www = UnityWebRequest.Get(url))
        {
            yield return www.SendWebRequest();

            if (www.result == UnityWebRequest.Result.Success)
            {
                usersArrayModel = JsonUtility.FromJson<UsersArrayModel>(www.downloadHandler.text);

                Ranking();
            }
            else
            {
                Debug.Log("Error");
            }
        }
    }

    private void Ranking()
    {
        foreach (Transform child in content)
        {
            Destroy(child.gameObject);
        }

        if(usersArrayModel != null && usersArrayModel.data != null)
        {
            foreach(var user in usersArrayModel.data)
            {
                GameObject newRankingRow = Instantiate(row, content);
                RankingView rowview = newRankingRow.GetComponent<RankingView>();


                if (rowview != null)
                {
                    rowview.SetData(user);
                }
            }
        }
    }
}
