using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowTrap : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject arrowSpawnVFX;
    [SerializeField] private int arrowSpeed;
    [SerializeField] private float arrowDistance;
    [SerializeField] private Vector3 arrowDirection;
    [SerializeField] private int coolDown;

    private Vector3 arrowSpawnLocation;


    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<PlayerController>())
        {
            for (int i = 0; i <3; i++)
            {
                arrowSpawnLocation = transform.GetChild(i).transform.position;
                Instantiate(projectile, arrowSpawnLocation, Quaternion.identity);
            }
            //Instantiate(projectile);

            //StartCoroutine(ShootingRoutine());
        }
    }

    private IEnumerator ShootingRoutine()
    {
        Instantiate(projectile, transform.position, Quaternion.identity);
        return null;
    }

}
