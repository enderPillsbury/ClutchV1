using Unity.VisualScripting;
using UnityEngine;

public class Spawning : MonoBehaviour
{
    public GameObject playerPrefab;

    public void spawnPlayer() //Feels pretty self-explanatory
    {
        Instantiate(playerPrefab, new Vector3(46, 3, -1), Quaternion.identity);
    }
}
