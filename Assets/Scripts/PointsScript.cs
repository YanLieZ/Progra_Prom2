using UnityEngine;
using TMPro;

public class PointsScript: MonoBehaviour
{
    [SerializeField] private int currentFibonacci = 1;
    [SerializeField] private int previousFibonacci = 0;
    [SerializeField] private TextMeshProUGUI playerScore;

    private void Update()
    {
        playerScore.text = "Puntos: " + GameDataManager.userHighscore.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cubo"))
        {
            AddPlayerScore();
        }
    }

    public void AddPlayerScore()
    {
        int pointsToAdd = currentFibonacci;

        GameDataManager.userHighscore += pointsToAdd;

        int nextFibonacci = currentFibonacci + previousFibonacci;
        previousFibonacci = currentFibonacci;
        currentFibonacci = nextFibonacci;
    }

 
}
