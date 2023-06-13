using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSword : MonoBehaviour
{
    PlayerController playerController;
    public bool aimingRight = true;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        Aim();
    }

    private void Aim()
    {

        float angle = Mathf.Atan2(PlayerController.Instance.transform.position.y, PlayerController.Instance.transform.position.x) * Mathf.Rad2Deg;

        print(angle);


        if (PlayerController.Instance.transform.position.x > transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        
        if (PlayerController.Instance.transform.position.x < transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, angle);
        }


        /*
        if (aimingRight)
        {



            Vector3 bowTarget = PlayerController.Instance.transform.position;

            Vector2 direction = (transform.position - bowTarget)+ new Vector3(0,0,-90);
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
        */

    }
    /*
    private void MouseFollowWithOffset()
    {
        Vector3 mousePos = Input.mousePosition;
        Vector3 playerScreenPoint = Camera.main.WorldToScreenPoint(PlayerController.Instance.transform.position);

        float angle = Mathf.Atan2(mousePos.y, mousePos.x) * Mathf.Rad2Deg;

        if (mousePos.x < playerScreenPoint.x)
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            ActiveWeapon.Instance.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    */


}
