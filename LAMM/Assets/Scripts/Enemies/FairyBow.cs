using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyBow : MonoBehaviour
{
    [SerializeField] GameObject fairyBow;

    private void Update()
    {
        FaceMouse();
    }

    private void FaceMouse()
    {
        Vector3 mousePosition = PlayerController.Instance.transform.position;
        
        Vector2 direction = transform.position - mousePosition;

        fairyBow.transform.right = -direction;
    }


}
