using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Summoner : MonoBehaviour
{
    [Tooltip("What enemy Prefab it will be summoned")]
    [SerializeField] private GameObject summon;
    [Tooltip("GameObject containing the summon Spawn Location")]
    [SerializeField] private GameObject summonLoc;
    [Tooltip("Number of spawn locations")]
    [SerializeField] private int numOfLoc = 2;
    [Tooltip("Number of spawn locations")]
    [SerializeField] private int summonCooldown = 10;

    private bool canSummon = true;
    private Vector3 placeToSummon;

    public void Summoning()
    {
        if (canSummon)
        {
            for (int i = 0; i < numOfLoc; i++)
            {
                placeToSummon = summonLoc.transform.GetChild(i).transform.position;
                Instantiate(summon, placeToSummon, Quaternion.identity);
                StartCoroutine(SummonCooldown());
            }

        }  

    }

    private IEnumerator SummonCooldown()
    {
        canSummon = false;
        yield return new WaitForSeconds(summonCooldown);
        canSummon = true;
    }
}
