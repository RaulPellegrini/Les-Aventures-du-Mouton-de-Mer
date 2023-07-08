using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;

public class Summoner : MonoBehaviour
{
    [SerializeField] private GameObject summon;
    [SerializeField] private GameObject summonLoc;
    [SerializeField] private GameObject summonVFX;
    [SerializeField] private int numOfLoc = 2;

    [SerializeField] private int summonCooldown = 10;

    [SerializeField] private float timeBetweenSummons = 1.5f;

    public bool canSummon = true;
    public bool isSummoning = false;
    private Vector3 placeToSummon;
    
    public void Summoning()
    {
        isSummoning = true;
        for (int i = 0; i < numOfLoc; i++)
        {
                placeToSummon = summonLoc.transform.GetChild(i).transform.position;
                Instantiate(summon, placeToSummon, Quaternion.identity);
                StartCoroutine(SummonCooldown());
        }

    }

    public void StartSummoningLightEffect() 
    { 
        for (int i = 0; i < numOfLoc; i++)
        {
            summonLoc.transform.GetChild(i).GetComponentInChildren<Light2D>().enabled = true;
                
        } 
    }

    public void EndSummoningLightEffect()
    {
        for (int i = 0; i < numOfLoc; i++)
        {
                summonLoc.transform.GetChild(i).GetComponentInChildren<Light2D>().enabled = false;
        }
    }

    public void SummoningVFX()
    {

        for (int i = 0; i < numOfLoc; i++)
        {
            placeToSummon = summonLoc.transform.GetChild(i).transform.position;
            Instantiate(summonVFX, placeToSummon, Quaternion.identity);
        }

    }


    private IEnumerator SummonCooldown()
    {
        isSummoning = false;
        canSummon = false;
        yield return new WaitForSeconds(summonCooldown);
        canSummon = true;
    }

    private IEnumerator TimeBetweenSummon()
    {
        canSummon = false;
        yield return new WaitForSeconds(timeBetweenSummons);
        canSummon = true;
    }

}
