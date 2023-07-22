using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateEndGame : MonoBehaviour
{
    [SerializeField] GameObject ActiveInventory;
    [SerializeField] GameObject EndGame;

    ActiveInventory bossCheck;
    EndGameEvent endGameActiviate;
    private void Awake()
    {
        bossCheck = ActiveInventory.GetComponent<ActiveInventory>();
        endGameActiviate = EndGame.GetComponent<EndGameEvent>();
    }
    private void Update()
    {
        if (bossCheck.endGameStarts)
        {
            endGameActiviate.enabled = true;
        }
    }
}
