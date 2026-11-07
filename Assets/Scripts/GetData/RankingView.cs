using TMPro;
using UnityEngine;

public class RankingView : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI usersName;
    [SerializeField] private TextMeshProUGUI users_highscore;
    [SerializeField] private TextMeshProUGUI users_lastlevel;
    [SerializeField] private TextMeshProUGUI users_status;

    public void SetData(UsersModel user)
    {
        usersName.text = user.user_name;
        users_highscore.text = user.users_highscore.ToString();
        users_lastlevel.text = user.users_lastlevel.ToString();
        users_status.text = user.users_status;   
    }

    public void SetAverage(AverageModel average)
    {
        users_lastlevel.text = average.users_lastlevel.ToString();
        users_highscore.text = average.promedio.ToString();
    }
}
