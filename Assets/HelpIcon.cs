using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HelpIcon : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject helpObject;
    // Start is called before the first frame update
    void Start()
    {
        helpObject.SetActive(false);
    }
    void IPointerEnterHandler.OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointerEnter");
        helpObject.SetActive(true);
    }

    void IPointerExitHandler.OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointerExit");
        helpObject.SetActive(false);

    }
}
