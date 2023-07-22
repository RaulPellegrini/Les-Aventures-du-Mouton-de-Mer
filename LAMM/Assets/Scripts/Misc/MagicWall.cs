using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MagicWall : MonoBehaviour
{
    [SerializeField] GameObject walls;
    [SerializeField] GameObject knightBoss;

    EnemyHealth health;

    private bool wallDone = false;

    private void Awake()
    {
        health = knightBoss.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        WallsOff();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>() && !wallDone)
        {
            walls.SetActive(true);
            wallDone = true;
        }
    }

    public void WallsOff()
    {
        if(health.currentHealth <= 0)
        {
            walls.SetActive(false);
        }

    }
}
