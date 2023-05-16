using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBow : MonoBehaviour
{
    public bool AimingRight = true;

    private void Update()
    {
         BowAim();
    }

    private void BowAim()
    {
        if (AimingRight)
        {
            Vector3 bowTarget = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - bowTarget;
            direction.Normalize();

            transform.right = -direction;

        }

        if (!AimingRight)
        {
            Vector3 bowTarget = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - bowTarget;
            direction.Normalize();

            transform.right = direction;


        }


    }


}
