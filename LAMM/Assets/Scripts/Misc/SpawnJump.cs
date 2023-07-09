using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class SpawnJump : MonoBehaviour
{
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;
    [SerializeField] Vector2 shadowPosition;

    public bool jumpEnd = false;

    private ShadowSpawnJump shadowSapwnjump;

    private void Awake()
    {
        shadowSapwnjump = GetComponentInChildren<ShadowSpawnJump>();
    }
    void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);

        Vector2 endPoint = new Vector2(randomX, randomY);

        float timePassed = 0f;

        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime;
            float linearT = timePassed / popDuration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);
            shadowSapwnjump.transform.position = Vector2.Lerp(startPoint, endPoint, linearT) - new Vector2(0f, height);
            yield return null;
        
        }

        StartCoroutine(ShadowFixRoutine());

    }

    private IEnumerator ShadowFixRoutine()
    {

        yield return new WaitForSeconds(4);
        shadowSapwnjump.ShadowToPosition();
    }



}
