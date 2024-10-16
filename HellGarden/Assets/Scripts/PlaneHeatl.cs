using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHeatl : MonoBehaviour
{
    public float Health = 100;
    public float Speed = 9;
    // Start is called before the first frame update
    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "BlackHole")
        {
            Health -= Time.deltaTime * Speed;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        { 
            Destroy(gameObject);
        }
    }
}
