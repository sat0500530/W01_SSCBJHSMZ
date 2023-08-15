using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchManager : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        this.GetComponent<Animator>().SetBool("BtIn", true);
    }// Start is called before the first frame update
   
   
}
