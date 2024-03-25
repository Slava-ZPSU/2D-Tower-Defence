using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
    // Visible fields

    // Invisible fields
    private List<GameObject> enemies = new List<GameObject>();
    private int level = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemies.Add(collision.gameObject);
            Debug.Log("Enemy entered");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy")) {
            enemies.Remove(collision.gameObject);
            Debug.Log("Enemy exited");
        }
    }


}
