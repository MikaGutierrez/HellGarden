using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HollForPimpochka : MonoBehaviour
{
    public BoxCollider2D SelfCollider;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (ThisIsMyItemPlugIt.IsPluged == true)
        {
            SelfCollider.enabled = false;
        }
        else if (ThisIsMyItemPlugIt.IsPluged == false)
        {
            SelfCollider.enabled = true;
        }
    }
}
