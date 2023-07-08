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
    [SerializeField] private bool waitToSummon = false;
    [SerializeField] private float timeBetweenSummons = 1.5f;
    [SerializeField] private float timeBetweenVFXandSummon = 0f;
    
    private Vector3 placeToSummon;
    private Animator myanimator;
    
    public bool canSummon = true;
    public bool isSummoning = false;

    readonly int STOPSUMMON_HASH = Animator.StringToHash("StopSummoning");

    private void Awake()
    {
        myanimator = GetComponent<Animator>();
    }

    public void Summoning()
    {
        StartCoroutine(SummonLoop());

    }

    private IEnumerator SummonLoop()
    {
        isSummoning = true;
        for (int i = 0; i < numOfLoc; i++)
        {
            placeToSummon = summonLoc.transform.GetChild(i).transform.position;

            Instantiate(summonVFX, placeToSummon, Quaternion.identity);

            if (waitToSummon) { yield return new WaitForSeconds(timeBetweenVFXandSummon); }

            Instantiate(summon, placeToSummon, Quaternion.identity);

            if (waitToSummon) { yield return new WaitForSeconds(timeBetweenSummons); }
        }
        myanimator.SetTrigger(STOPSUMMON_HASH);
        isSummoning = false;
        StartCoroutine(SummonCooldown());
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
        canSummon = false;
        yield return new WaitForSeconds(summonCooldown);
        canSummon = true;
    }

}
