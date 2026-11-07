using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelScript : MonoBehaviour
{
    public int nivel;

    private void Awake()
    {
        GameDataManager.userLastLevel = nivel;
        
    }





}
