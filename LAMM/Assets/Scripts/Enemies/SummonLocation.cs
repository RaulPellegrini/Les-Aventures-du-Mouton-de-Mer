using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SummonLocation : MonoBehaviour
{
    public bool summonFacingRight = true;
    private void Update()
    {
        SummoningSpotRotation();
    }

    private void SummoningSpotRotation()
    {
        
        if (summonFacingRight)
        {
            Vector3 summonLocation = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - summonLocation;
            direction.Normalize();

            transform.right = -direction;

        }

        if (!summonFacingRight )
        {
            Vector3 summonLocation = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - summonLocation;
            direction.Normalize();

            transform.right = direction;


        }
       
    }
}
