using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSword : MonoBehaviour
{
    private VampireSword vampireSword;

    private void Awake()
    {
        vampireSword = GetComponent<VampireSword>();
    }

    private void Update()
    {
        SwordFollowThePlayer();
    }

    private void SwordFollowThePlayer()
    {
        Vector3 vampirePos = transform.position;
        Vector3 playerPos = PlayerController.Instance.transform.position;

        float angle = Mathf.Atan2(vampirePos.y, vampirePos.x) * Mathf.Rad2Deg;

        if (vampirePos.x < playerPos.x)
        {
            vampireSword.transform.rotation = Quaternion.Euler(0, -180, angle);
        }
        else
        {
            vampireSword.transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
}
