using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [SerializeField] private GameObject nameBox;

    public void PlayerDeath()
    {
        Time.timeScale = 0;
        GameDataManager.userStatus = "perdio";
        nameBox.SetActive(true);
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Cubo")
        {
            PlayerDeath();
        }
    }
}
