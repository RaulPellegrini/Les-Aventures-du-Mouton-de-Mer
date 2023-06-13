using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBow : MonoBehaviour
{
    public bool aimingRight = true;

    private void Update()
    {
         BowAim();
    }

    private void BowAim()
    {
        if (aimingRight)
        {
            Vector3 bowTarget = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - bowTarget;
            direction.Normalize();

            transform.right = -direction;

        }

        if (!aimingRight)
        {
            Vector3 bowTarget = PlayerController.Instance.transform.position;

            Vector2 direction = transform.position - bowTarget;
            direction.Normalize();

            transform.right = direction;


        }


    }


}
