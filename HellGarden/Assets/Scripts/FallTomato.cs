using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FallTomato : MonoBehaviour
{
    public int ToGiveHearts;
    public GameObject particles;
    public GameObject self;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {

            ThePlayer.Hears += ToGiveHearts;
            Instantiate(particles, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(transform.rotation.x, transform.rotation.y, 0f));
            Destroy(self);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
