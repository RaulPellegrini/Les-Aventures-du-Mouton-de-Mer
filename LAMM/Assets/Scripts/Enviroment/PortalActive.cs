using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalActive : MonoBehaviour
{

    [SerializeField] GameObject demon;
    [SerializeField] GameObject portal;

    private EnemyHealth health;

    private void Awake()
    {
        health = demon.GetComponent<EnemyHealth>();
    }

    private void Update()
    {
        PortalCheck();
    }

    private void PortalCheck()
    {
        if (health.currentHealth <= 0)
        {
            portal.SetActive(true);
        }
    }
}
