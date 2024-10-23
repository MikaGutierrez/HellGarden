using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class FallTomato : MonoBehaviour
{
    public int ToGiveHearts;
    public GameObject particles;
    public GameObject self;
    [Header("Paricles")]
    public GameObject[] Hearts;
    public GameObject[] BroukenHearts;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground")
        {
            if (ToGiveHearts > 0)
            {
                Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
            else if (ToGiveHearts < 0)
            {
                Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
            }
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
