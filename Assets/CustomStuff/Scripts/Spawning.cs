using Unity.VisualScripting;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public void spawnPlayer()
    {
        Instantiate(playerPrefab, new Vector3(46, 3, -1), Quaternion.identity);
    }
}
