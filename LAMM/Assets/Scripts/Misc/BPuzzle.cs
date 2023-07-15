using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BPuzzle : MonoBehaviour
{

    [SerializeField] GameObject Button1;
    [SerializeField] GameObject Button2;
    [SerializeField] GameObject Button3;
    [SerializeField] GameObject Button4;
    [SerializeField] GameObject Lever;
    [SerializeField] GameObject LeverVFX;

    private Vector3 wallPosition;
    private bool vfx = false;
    private void Update()
    {
        ButtonVeriification();
    }
    private void ButtonVeriification()
    {
        
        if(Button1.GetComponent<Button>().down && Button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }

        if (Button2.GetComponent<Button>().down && Button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }

        if (Button4.GetComponent<Button>().down && Button3.GetComponent<Button>().down)
        {
            PuzzleReset();
        }


        if ( Button1.GetComponent<Button>().down && Button2.GetComponent<Button>().down && Button4.GetComponent<Button>().down)
        {
            Lever.SetActive(false);
            
            if (!vfx)
            {
                for (int i = 0; i < 4; i++)
                {
                    wallPosition = Lever.transform.GetChild(i).position;
                    Instantiate(LeverVFX, wallPosition, Quaternion.identity);

                }
            }

            vfx = true;
        }

    }

    private void PuzzleReset()
    {
        Button1.GetComponent<Button>().ButtonReset();
        Button2.GetComponent<Button>().ButtonReset();
        Button3.GetComponent<Button>().ButtonReset();
        Button4.GetComponent<Button>().ButtonReset();
    }

}
