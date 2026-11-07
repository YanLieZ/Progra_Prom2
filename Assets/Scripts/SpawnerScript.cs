using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using UnityEngine.SceneManagement;

public class SpawnersScript : MonoBehaviour
{
    [SerializeField] private ObstacleSpawner[] generators;
    [SerializeField] private float spawnCd;
    [SerializeField] private float time = 0;
    [SerializeField] private float duration;
    [SerializeField] private GameObject namePanel;
    [SerializeField] private GameObject nextLevel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(StartSpawns());
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (time > 30)
        {
            StopCoroutine(StartSpawns());
        } 

        CheckLevelWin();
        CheckGameWin();
    }

    IEnumerator StartSpawns()
    {
        int randomIndex = Random.Range(0, generators.Length);
        while (true)
        {
            generators[randomIndex].GenerateObstacles();
            yield return new WaitForSeconds(spawnCd);
            randomIndex = Random.Range(0, generators.Length);
        }
    }

    public void ContinueLevel()
    {
        SceneManager.LoadScene(GameDataManager.userLastLevel + 1);
    }

    private void CheckGameWin()
    {
        if (GameDataManager.userLastLevel == 3 && time > 45f)
        {
            Time.timeScale = 0;
            namePanel.SetActive(true);
            GameDataManager.userStatus = "gano";
        }
    }

    private void CheckLevelWin()
    {
        if (time > duration)
        {
            Time.timeScale = 0;
            nextLevel.SetActive(true);
        }
    }



}
