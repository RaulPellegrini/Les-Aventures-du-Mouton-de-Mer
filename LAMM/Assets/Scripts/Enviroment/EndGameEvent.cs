using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UIElements;

public class EndGameEvent : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject summonVFX;
    [SerializeField] GameObject monster;
    [SerializeField] GameObject monster2;
    [SerializeField] GameObject monster3;
    [SerializeField] GameObject monster4;
    [SerializeField] GameObject monster5;
    [SerializeField] GameObject monster6;
    [SerializeField] GameObject monster7;
    [SerializeField] GameObject monster8;
    [SerializeField] GameObject monsterSpawnPosition;
    [SerializeField] GameObject mushroomBoss;
    [SerializeField] GameObject mushroomSpawnPosition;
    [SerializeField] GameObject knightBoss;
    [SerializeField] GameObject knightSpawnPosition;
    [SerializeField] GameObject demonBoss;
    [SerializeField] GameObject demonSpawnPosition;
    [SerializeField] float respawnCooldownTime = 15f;

    private PlayerHealth playerHealth;
    private BoxCollider2D boxCollider;

    private Vector3 knightLocation;
    private Vector3 mushroomLocation;
    private Vector3 demonLocation;

  

    private void Awake()
    {
        knightLocation = knightSpawnPosition.transform.position;
        mushroomLocation = mushroomSpawnPosition.transform.position;
        demonLocation = demonSpawnPosition.transform.position;
        
        
        playerHealth = player.GetComponent<PlayerHealth>();
        boxCollider = GetComponent<BoxCollider2D>();
    }

    private void Update()
    {
        //HellOnEarth();
        StopEverything();
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.GetComponent<PlayerController>())
        {
            Apocalipse();
            boxCollider.enabled = false;
        }
    }

    private void Apocalipse()
    {
        StartCoroutine(BossSummonRoutine());
        StartCoroutine(MinionsSummonRoutine());
        StartCoroutine(BossCooldownRoutine());
    }


    private IEnumerator BossCooldownRoutine()
    {
        yield return new WaitForSeconds(respawnCooldownTime);
        Apocalipse();
    }

    private IEnumerator BossSummonRoutine()
    {
        Instantiate(summonVFX, mushroomLocation, Quaternion.identity);
        Instantiate(summonVFX, knightLocation, Quaternion.identity);
        Instantiate(summonVFX, demonLocation, Quaternion.identity);
        yield return new WaitForSeconds(1);
        Instantiate(mushroomBoss, mushroomLocation, Quaternion.identity);
        Instantiate(knightBoss, knightLocation, Quaternion.identity);
        Instantiate(demonBoss, demonLocation, Quaternion.identity);   

    }
   
    private IEnumerator MinionsSummonRoutine()
    {

        for (int i = 0; i < 7; i++)
        {
            Instantiate(summonVFX, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
        }

        yield return new WaitForSeconds(1);
        for (int i = 0; i < 7; i++)
        {
            int randomNum = Random.Range(0, 8);

            if (randomNum == 0)
            {
                Instantiate(monster, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 1)
            {
                Instantiate(monster2, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 2)
            {
                Instantiate(monster3, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 3)
            {
                Instantiate(monster4, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 4)
            {
                Instantiate(monster5, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 5)
            {
                Instantiate(monster6, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 6)
            {
                Instantiate(monster7, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            if (randomNum == 7)
            {
                Instantiate(monster8, transform.GetChild(0).GetChild(i).transform.position, Quaternion.identity);
            }
            else
            {
                yield return null;
            }

        }
    }

    private void StopEverything()
    {
        if (playerHealth.IsDead)
        {
            StopAllCoroutines();
        }
    }


    /*    private IEnumerator LoadSceneRoutine()
    {
        //yield return new WaitForSeconds(waitToLoadTime);
        
        while (waitToLoadTime >= 0)
        { 
            waitToLoadTime -= Time.deltaTime;
            yield return null;
        
        }
        SceneManager.LoadScene(sceneToLoad);
    }*/
}
