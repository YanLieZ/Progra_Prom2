using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class Last10Script : MonoBehaviour
{
    private const string url = "http://localhost/Progra_Flappy/show_last10.php";
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

        if (usersArrayModel != null && usersArrayModel.data != null)
        {
            foreach (var user in usersArrayModel.data)
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
