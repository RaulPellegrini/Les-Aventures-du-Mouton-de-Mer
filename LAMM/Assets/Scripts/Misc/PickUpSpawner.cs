using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldenCoinPreFab;

    public void DropItems()
    {
        Instantiate(goldenCoinPreFab, transform.position, Quaternion.identity);
    }
}
