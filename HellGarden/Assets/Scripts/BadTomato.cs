using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class BadTomato : MonoBehaviour
{
    public GameObject particles;
    public GameObject self;
    void Start()
    {
        StartCoroutine(GiveHearts());
    }
    private void OnMouseDown()
    {
        ThePlayer.Hears += 1;
        Instantiate(particles, new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Destroy(self);
    }

    private IEnumerator GiveHearts()
    {
        yield return new WaitForSeconds(3);
        ThePlayer.Hears -= 1;
        StartCoroutine(GiveHearts());

    }
}
