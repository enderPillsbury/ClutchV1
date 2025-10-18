using System.Data.Common;
using UnityEngine;
using UnityEngine.Events;

public class PlayerDestroy : MonoBehaviour
{
    public UnityEvent openUI;
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag.Equals("Player"))
        {
            Destroy(col.gameObject);
            openUI.Invoke();
        }
        
    }
}
