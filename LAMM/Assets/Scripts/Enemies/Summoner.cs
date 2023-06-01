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

    public bool canSummon = true;
    private Vector3 placeToSummon;

    public void Summoning()
    {
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
                
             /*   
             placeToSummon = summonLoc.transform.GetChild(i).transform.position;
             Instantiate(lightEffect, placeToSummon, Quaternion.identity);

             transform.GetChild(0).GetComponent<Light2D>().intensity = Mathf.MoveTowards(1f,4f,timer/1);
             timer += Time.deltaTime;
             */
            
        } 
    }

    public void EndSummoningLightEffect()
    {
        for (int i = 0; i < numOfLoc; i++)
        {
                summonLoc.transform.GetChild(i).GetComponentInChildren<Light2D>().enabled = false;

                /*   
                placeToSummon = summonLoc.transform.GetChild(i).transform.position;
                Instantiate(lightEffect, placeToSummon, Quaternion.identity);

                transform.GetChild(0).GetComponent<Light2D>().intensity = Mathf.MoveTowards(1f,4f,timer/1);
                timer += Time.deltaTime;
                */
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
        yield return new WaitForSeconds(summonCooldown);
        canSummon = true;
    }


}
