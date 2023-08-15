using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SwitchCounter : MonoBehaviour
{
    public List<GameObject> SwitchMaster;
    public int SwitchOnnumber = 0;
    public int SwitchLength;

    // Start is called before the first frame update
    void Start()
    {
        var array = GameObject.FindGameObjectsWithTag("Switch");
        for (int i = 0; i < array.Length; i++)
        {
            SwitchMaster.Add(array[i]);
        }
        SwitchLength = SwitchMaster.Count;
    }

    private void Update()
    {
        if(!(SwitchLength == SwitchOnnumber))
        {
            foreach (var s in SwitchMaster.ToList())
            { 
                if (s.GetComponent<BoxCollider2D>().isTrigger)
                {
                    SwitchOnnumber++;
                    SwitchMaster.Remove(s);
                }

            }

        }
        else {
            this.gameObject.transform.GetChild(0).gameObject.SetActive(true);
        }
        


    }
}
