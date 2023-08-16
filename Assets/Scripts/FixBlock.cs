using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FixBlock : MonoBehaviour
{
    bool fixChaker = true;
    FixBlock originPlatform;
    List<FixBlock> childPlatforms = new List<FixBlock>();
    bool isOrigin = true;

    public void Start()
    {
        
    }
    public void SetOrigin(FixBlock origin)
    {
        isOrigin = false;
        originPlatform = origin;
    }

    public void EndFix()
    {
        gameObject.transform.SetParent(null);
        OnDestroyGameObject();
        Destroy(this);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<FixableObject>(out _))
        {

            var origin = isOrigin ? this : originPlatform;
            collision.transform.SetParent(origin.gameObject.transform);

            bool hasComponent = collision.transform.TryGetComponent<FixBlock>(out _);
            bool hasPComponent = collision.transform.TryGetComponent<PlayerController>(out _);
            if (!hasComponent&&!hasPComponent)
            {
                var newFixBlock = collision.gameObject.AddComponent<FixBlock>();
                newFixBlock.SetOrigin(origin);
                childPlatforms.Add(newFixBlock);
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

    public void OnDestroyGameObject()
    {
        foreach (var f in childPlatforms)
        {
            if (f != null)
            {
                f.EndFix();
            }
        }
    }

}

