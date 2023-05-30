using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeToRed : MonoBehaviour
{

    [SerializeField] float colorChangeTime = 2;
    [SerializeField] Color finalColor = Color.red;
    [Tooltip("Lower the time, faster the change")]

    Renderer spriteRenderer;
    private float timer = 0;
    private Color initialColor;
    private EnemyAI enemyAI;


    public bool changingColor = false;
    public bool colorChanged = false;

    void Start()
    {
        spriteRenderer = GetComponent<Renderer>();
        initialColor = spriteRenderer.material.color;
        enemyAI = GetComponent<EnemyAI>();

    }

    private void Update()
    {
        if (changingColor && !colorChanged)
        {
            spriteRenderer.material.color = Color.Lerp(initialColor, finalColor, timer / colorChangeTime);
            timer += Time.deltaTime;

        }

        if( spriteRenderer.material.color == finalColor) {colorChanged = true;}

        if(colorChanged)
        {
            spriteRenderer.material.color = Color.Lerp(Color.red, Color.white, timer / colorChangeTime);
            timer += Time.deltaTime;
        }
        
    }


}
