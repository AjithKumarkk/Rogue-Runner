using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject playerPrefab; // Reference to your player prefab

    void Start()
    {
        InstantiatePlayer();
        Physics2D.IgnoreLayerCollision(7, 8, false);
    }

    void InstantiatePlayer()
    {
        // Instantiate the player prefab
        Instantiate(playerPrefab, new Vector3(-11f,3f,0f), Quaternion.identity);
    }
}
