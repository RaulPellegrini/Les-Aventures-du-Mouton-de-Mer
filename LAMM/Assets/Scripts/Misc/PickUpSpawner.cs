using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSpawner : MonoBehaviour
{
    [SerializeField] private GameObject goldenCoin, healthGlobe, staminaGlobe;
    [SerializeField] private bool ItemDrop = true;
    public void DropItems()
    {

        if (ItemDrop)
        {
            int randomNum = Random.Range(1, 4);

            if (randomNum == 1)
            {
                Instantiate(healthGlobe, transform.position, Quaternion.identity);
            }

            if (randomNum == 2)
            {
                Instantiate(staminaGlobe, transform.position, Quaternion.identity);
            }

            if (randomNum == 3)
            {
                int randomAmountOfGold = Random.Range(1, 4);
                for (int i = 0; i < randomAmountOfGold; i++)
                {
                    Instantiate(goldenCoin, transform.position, Quaternion.identity);
                }

            }

        }
        else
        {

        }

    }
}
