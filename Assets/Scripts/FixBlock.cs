using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixBlock : MonoBehaviour
{
    bool fixChaker = true;
    public void Start()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
            collision.transform.SetParent(transform);

            bool hasComponent = collision.transform.TryGetComponent<FixBlock>(out _);
            bool hasPComponent = collision.transform.TryGetComponent<PlayerController>(out _);
            Debug.Log("�Ƚ��� : "+hasComponent); 
            Debug.Log("�÷��̾���Ʈ�ѷ� : " + hasPComponent);
            if (!hasComponent&&!hasPComponent)
            {
                Debug.Log("��������");
                collision.gameObject.AddComponent<FixBlock>();
            }
            
        }
           
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.transform.CompareTag("Ground"))
        {
           
                collision.transform.SetParent(null);
           

        }
    }

}

