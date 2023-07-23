using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ArrowTrap : MonoBehaviour
{

    [SerializeField] GameObject projectile;
    [SerializeField] GameObject arrowSpawnVFX;
    [SerializeField] private Vector3 arrowDirection;
    [SerializeField] private int coolDown;


    private Vector3 arrowSpawnLocation;

    private void OnTriggerStay2D(Collider2D other)
    {

        if (other.gameObject.GetComponent<PlayerController>())
        {
            for (int i = 0; i <3; i++)
            {
                arrowSpawnLocation = transform.GetChild(i).transform.position;
                GameObject newArrow = Instantiate(projectile, arrowSpawnLocation, Quaternion.identity);
                newArrow.transform.right = newArrow.transform.position - arrowDirection;

                /*GameObject newBullet = Instantiate(bulletPrefab, arrowDirection, Quaternion.identity);
                newBullet.transform.right = newBullet.transform.position - transform.position;
                */
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
