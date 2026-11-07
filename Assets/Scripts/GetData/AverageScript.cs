using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

[Serializable]
public class AverageModel
{
    public int users_lastlevel;
    public int promedio;
}

[Serializable]
public class AverageArrayModel
{
    public AverageModel[] data;
}

public class AverageScript : MonoBehaviour
{
    private const string url = "http://localhost/Progra_Flappy/show_average.php";
    [SerializeField] private AverageArrayModel averageArrayModel;

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
                averageArrayModel = JsonUtility.FromJson<AverageArrayModel>(www.downloadHandler.text);

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

        if (averageArrayModel != null && averageArrayModel.data != null)
        {
            foreach (var user in averageArrayModel.data)
            {
                GameObject newRankingRow = Instantiate(row, content);
                RankingView rowview = newRankingRow.GetComponent<RankingView>();

                if(rowview != null)
                {
                    rowview.SetAverage(user);
                }
            }
        }
    }
}
