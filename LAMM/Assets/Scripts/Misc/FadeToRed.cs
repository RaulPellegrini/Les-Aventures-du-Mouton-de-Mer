using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeToRed : MonoBehaviour
{
    SpriteRenderer spriteRenderer;

    [SerializeField] float fadingSpeed = 0.05f;
    [SerializeField] float fadeToRedAmount = 0f;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();

        Color color = spriteRenderer.color;

        // Setting values for Green and Blue
        color.g = 1f;
        color.b = 1f;

        spriteRenderer.color = color;
    }

    IEnumerator fadeToRedRoutine()
    {
        for (float i=1f; i >= fadeToRedAmount; i -= 0.05f)
        {
            Color color = spriteRenderer.color;

            color.g = i;
            color.b = i;

            yield return new  WaitForSeconds(fadingSpeed);
        }
    }

    public void fadeToRed()
    {
        StartCoroutine(fadeToRedRoutine());
    }
}
