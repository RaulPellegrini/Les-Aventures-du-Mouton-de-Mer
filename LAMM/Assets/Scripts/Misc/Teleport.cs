using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] bool horizontal = false;
    [SerializeField] bool vertical = false;
    [SerializeField] float positionX = 0f;
    [SerializeField] float positionY = 0f;

    Vector2 teleportPosition = new Vector2(0f,0f);

    private void Awake()
    {
        teleportPosition = new Vector2(positionX, positionY);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        TeleportLocation();
        PlayerController.Instance.transform.position = teleportPosition;   
    }

    private Vector2 TeleportLocation()
    {
        if (horizontal) { teleportPosition.y = PlayerController.Instance.transform.position.y; }
        if (vertical) { teleportPosition.x = PlayerController.Instance.transform.position.x; }

        return teleportPosition;
    }

}
