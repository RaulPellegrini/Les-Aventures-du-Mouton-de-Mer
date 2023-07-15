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

    private void Update()
    {
        ButtonVeriification();
    }
    private void ButtonVeriification()
    {
        if ( Button1.GetComponent<Button>().down && Button2.GetComponent<Button>().down && Button3.GetComponent<Button>().down && Button4.GetComponent<Button>().down)
        {
            Lever.SetActive(true);
        }



    }
}
