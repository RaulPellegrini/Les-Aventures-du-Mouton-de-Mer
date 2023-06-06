using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FadeToRed : MonoBehaviour
{

    [SerializeField] float colorChangeTime = 4;
    [SerializeField] Color initialColor;
    [SerializeField] Color finalColor = Color.red;
    [SerializeField] float colorChangeCooldown = 0f;

    Renderer spriteRenderer;

    private float timer = 0;
    
    public bool colorChanging = false;
    public bool colorFinal = false;

    private bool canChangeColor = true;
    private bool colorSwich = false;
    /*
        private enum State
        {

        }

        private State state;
    */

    private void Awake()
    {
        spriteRenderer = GetComponent<Renderer>();
        initialColor = spriteRenderer.material.color;
    }

    private void Update()
    {

        if (colorChanging && canChangeColor)
        {
            ColorToFinal();
        }

        else
        {
            ColorToStart();
        }

    }


    private void ColorToFinal()
    {
        spriteRenderer.material.color = Color.Lerp(initialColor, finalColor, (timer / colorChangeTime));
        timer += Time.deltaTime;

        if (spriteRenderer.material.color == finalColor)
        {
            colorFinal = true;
            StartCoroutine(ColorChangeCooldownRoutine());
            ColorChangeToStart();

        }
    }

    private void ColorToStart()
    {
        spriteRenderer.material.color = Color.Lerp(initialColor, Color.white, timer / colorChangeTime);
        timer += Time.deltaTime;


        if (spriteRenderer.material.color == Color.white)
        {
            initialColor = spriteRenderer.material.color;
            timer = 0;
        }
    }

    public void ColorChangeToFinal()
    {
        if (!colorChanging)
        {
            timer = 0;
            initialColor = spriteRenderer.material.color;
            colorChanging = true;
            colorSwich = true;
        }

    }

    public void ColorChangeToStart()
    {
        if (colorSwich)
        {
            timer = 0;
            initialColor = spriteRenderer.material.color;
            colorChanging = false;
            colorSwich = false;
        }

    }

    private IEnumerator ColorChangeCooldownRoutine()
    {
        canChangeColor = false;
        yield return new WaitForSeconds(colorChangeCooldown);
        canChangeColor = true;
    }

}
