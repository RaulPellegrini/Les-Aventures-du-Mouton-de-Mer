using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    readonly int UP_HASH = Animator.StringToHash("Up");
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            for (int i = 0; i < 117; i++)
            {
                transform.GetChild(i).GetComponent<Animator>().SetTrigger(UP_HASH);
            }

        }
    }
}
