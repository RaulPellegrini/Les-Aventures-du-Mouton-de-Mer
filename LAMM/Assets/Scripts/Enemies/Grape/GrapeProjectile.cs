using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapeProjectile : MonoBehaviour
{
    [SerializeField] private float duration = 1f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 3f;
    [SerializeField] private float heightI = 0f;
    [SerializeField] private GameObject grapeProjectileShadow;
    [SerializeField] private float shadowHeight = -0.3f;
    [SerializeField] private GameObject splatterPrefab;
    //[SerializeField] public float grapeDamage = 1;
    [SerializeField] private GameObject particleOnHitPrefabVFX;

    private void Start()
    {
        GameObject grapeShadow = Instantiate(grapeProjectileShadow, transform.position + new Vector3(0, shadowHeight, 0), Quaternion.identity);
        Vector3 playerPos = PlayerController.Instance.transform.position;
        Vector3 grapeShadowStartPosition = grapeShadow.transform.position;


        StartCoroutine(ProjectileCurveRoutine(transform.position, playerPos));
        StartCoroutine(MoveGrapeShadowRoutine(grapeShadow, grapeShadowStartPosition, playerPos));
    }

    private IEnumerator ProjectileCurveRoutine(Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / duration;
            float heightT = animCurve.Evaluate(linearT);

            //Testing if the ball cam come from the sky, the heightI should be 0f,
            float height = Mathf.Lerp(heightI, heightY, heightT);

            transform.position = Vector2.Lerp(startPosition, endPosition, linearT) + new Vector2(0f, height);

            yield return null;
        }

        Instantiate(splatterPrefab, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }

    private IEnumerator MoveGrapeShadowRoutine(GameObject grapeShadow, Vector3 startPosition, Vector3 endPosition)
    {
        float timePassed = 0f;

        while (timePassed < duration)
        {
            float linearT = timePassed / duration;
            timePassed += Time.deltaTime;
            grapeShadow.transform.position = Vector2.Lerp(startPosition, endPosition, linearT);
            yield return null;
        }

        Destroy(grapeShadow);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Indestructible indesctruitible = other.gameObject.GetComponent<Indestructible>();

        if (indesctruitible)
        {
            Instantiate(particleOnHitPrefabVFX, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
