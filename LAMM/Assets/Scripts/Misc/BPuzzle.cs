using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPuzzle : MonoBehaviour
{

    [SerializeField] GameObject button1;
    [SerializeField] GameObject button2;
    [SerializeField] GameObject button3;
    [SerializeField] GameObject button4;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject wallVFX;

    private Vector3 wallPosition;
    private bool vfx = false;
    private void Update()
    {
        ButtonVeriification();
    }
    private void ButtonVeriification()
    {
        
        if(button1.GetComponent<Button>().down && button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }

        if (button2.GetComponent<Button>().down && button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }

        if (button4.GetComponent<Button>().down && button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }


        if ( button1.GetComponent<Button>().down && button2.GetComponent<Button>().down && button4.GetComponent<Button>().down)
        {
            wall.SetActive(false);
            
            if (!vfx)
            {
                for (int i = 0; i < 4; i++)
                {
                    wallPosition = wall.transform.GetChild(i).position;
                    Instantiate(wallVFX, wallPosition, Quaternion.identity);

                }
            }

            vfx = true;
        }

    }

    private void PuzzleReset()
    {
        button1.GetComponent<Button>().ButtonReset();
        button2.GetComponent<Button>().ButtonReset();
        button3.GetComponent<Button>().ButtonReset();
        button4.GetComponent<Button>().ButtonReset();
    }

}
