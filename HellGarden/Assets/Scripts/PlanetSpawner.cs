using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlanetSpawner : MonoBehaviour
{

    public GameObject[] Planets;
    public bool TurnOnBool = false;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnThem());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnThem()
    {
        yield return new WaitForSeconds(Random.Range(0.5f, 1));
        if (ForAnimation.TheUltimateBool == true)
        { 
        Instantiate(Planets[Random.Range(0, Planets.Length)], new Vector3(transform.position.x, transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        }
        StartCoroutine(SpawnThem());
    }

}
