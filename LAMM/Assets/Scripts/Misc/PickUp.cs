using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private enum PickUpType
    {
        GoldCoin,
        StaminaGlobe,
        HealthGlobe,
    }

    [SerializeField] PickUpType pickUpType;
    [SerializeField] private float pickUpDistance = 5f;
    [SerializeField] private float moveSpeed = 3f;
    [SerializeField] private float accelarationRate = .2f;
    [SerializeField] private AnimationCurve animCurve;
    [SerializeField] private float heightY = 1.5f;
    [SerializeField] private float popDuration = 1f;

    private Vector3 moveDir;
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        StartCoroutine(AnimCurveSpawnRoutine());
    }

    private void Update()
    {
        Vector3 PlayerPos = PlayerController.Instance.transform.position;

        if (Vector3.Distance(transform.position, PlayerPos) < pickUpDistance)
        {
            moveDir = (PlayerPos - transform.position).normalized;
            moveSpeed += accelarationRate;
        } else {
            moveDir = Vector3.zero;
            moveSpeed = 0f;
        }

    }

    private void FixedUpdate()
    {
        rb.velocity = moveDir * moveSpeed * Time.deltaTime;
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<PlayerController>())
        {
            DetectPickupType();
            Destroy(gameObject);
        }
    }

    private IEnumerator AnimCurveSpawnRoutine()
    {
        Vector2 startPoint = transform.position;
        float randomX = transform.position.x + Random.Range(-2f, 2f);
        float randomY = transform.position.y + Random.Range(-1f, 1f);
        
        Vector2 endPoint = new Vector2(randomX,randomY);

        float timePassed = 0f;

        while (timePassed < popDuration)
        {
            timePassed += Time.deltaTime; 
            float linearT = timePassed / popDuration;
            float heightT = animCurve.Evaluate(linearT);
            float height = Mathf.Lerp(0f, heightY, heightT);

            transform.position = Vector2.Lerp(startPoint, endPoint, linearT) + new Vector2(0f, height);

            yield return null;
        }
    }

    private void DetectPickupType()
    {
        switch(pickUpType)
        {
            case PickUpType.GoldCoin:
                EconomyManager.Instance.UpdateCurrentGold();
                
                break;

            case PickUpType.HealthGlobe:
                PlayerHealth.Instance.HealPlayer();

                break;

            case PickUpType.StaminaGlobe:
                Stamina.Instance.RefreshStamina();

                break;

            default: 
                break;

        }
    }
}
