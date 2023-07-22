using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndGame : MonoBehaviour
{
    [SerializeField] GameObject ActiveInventory;
    [SerializeField] GameObject EndGame;

    ActiveInventory bossCheck;

    private void Awake()
    {
        bossCheck = ActiveInventory.GetComponent<ActiveInventory>();

    }
    private void Update()
    {
        if (bossCheck.endGame)
        {
            EndGame.SetActive(true);
        }
    }
}
