using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{

    [SerializeField] private GameObject treeGuard;
    private Vector2 treeGuardSpawn;
    private void SpawnTreeGuard()
    {
        /*
        treeGuardSpawnPoint = (transform.position - PlayerController.Instance.transform.position)/2;
        */

        //treeGuardSpawn = Vector2.Distance(PlayerController.Instance.transform.position, transform.position);

        Instantiate(treeGuard, treeGuardSpawn, Quaternion.identity);

    }
}
