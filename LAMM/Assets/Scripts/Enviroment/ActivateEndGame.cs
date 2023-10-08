using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndGame : MonoBehaviour
{
    [SerializeField] GameObject ActiveInventory;
    [SerializeField] GameObject EndGame;
    [SerializeField] GameObject signs;

    ActiveInventory bossCheck;
    private static bool endGameStart = false;

    private void Awake()
    {
        bossCheck = ActiveInventory.GetComponent<ActiveInventory>();

    }
    private void Update()
    {
        if (bossCheck.endGame)
        {
            endGameStart = true;

        }

        if (endGameStart)
        {
            signs.SetActive(false);
            EndGame.SetActive(true);
        }
    }

}
