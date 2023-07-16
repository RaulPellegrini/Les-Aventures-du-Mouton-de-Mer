using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour
{

    [SerializeField] private float colliderTime = 1.5f;
    private void StartCollider()
    {
        StartCoroutine(SpikeColliderRoutine());
    }

    private IEnumerator SpikeColliderRoutine()
    {
        transform.GetComponent<BoxCollider2D>().enabled = true;
        yield return new WaitForSeconds(colliderTime);
        transform.GetComponent <BoxCollider2D>().enabled = false;
    }
}
