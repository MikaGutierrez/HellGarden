using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHoleFlower : MonoBehaviour
{
    [Header("ChangeGameObjects")]
    public GameObject Stage1;
    public GameObject Stage2;
    public GameObject Stage3;
    [Header("Flower Health")]
    public float FlowerHealth;
    public float MaxFlowerHealth = 100;
    public float MinFlowerHealth = 0;
    public int FlowerStage;
    public float FlowerHealthLooseSpeed = 7f;
    [Header("OtherStates")]
    public float PlanertFood = 14;
    public float SecondsToGetHeart = 2;
    [Header("Paricles")]
    public GameObject[] Hearts;
    public GameObject[] BroukenHearts;
    // Start is called before the first frame update


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "ThePlanet")
        {
            FlowerHealth += Time.deltaTime * PlanertFood;
        }
    }
    void Start()
    {
        Stage1.SetActive(false);
        Stage2.SetActive(false);
        Stage3.SetActive(false);
        StartCoroutine(GiveHearts());
    }

    // Update is called once per frame
    void Update()
    {
        if (FlowerHealth >= MinFlowerHealth)
        {
            FlowerHealth -= Time.deltaTime * FlowerHealthLooseSpeed;
        }

        if (FlowerHealth > MaxFlowerHealth)
        {
            FlowerHealth = MaxFlowerHealth;
        }

        if (FlowerHealth >= 70)
        {
            FlowerStage = 0;
        }
        else if (FlowerHealth < 70 && FlowerHealth > 40)
        {
            FlowerStage = 1;
        }
        else if (FlowerHealth < 40 && FlowerHealth > 0)
        {
            FlowerStage = 2;
        }



        if (FlowerStage == 0)
        {
            Stage1.SetActive(true);
            Stage2.SetActive(false);
            Stage3.SetActive(false);
        }
        else if (FlowerStage == 1)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(true);
            Stage3.SetActive(false);
        }
        else if (FlowerStage == 2)
        {
            Stage1.SetActive(false);
            Stage2.SetActive(false);
            Stage3.SetActive(true);
        }

    }
    private IEnumerator GiveHearts()
    {
        yield return new WaitForSeconds(SecondsToGetHeart);
        if (FlowerStage == 2)
        {
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears -= 4;
        }
        else if (FlowerStage == 1)
        {
            yield return new WaitForSeconds(2);
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 4.776672f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears -= 2;
        }
        else if (FlowerStage == 0)
        {
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears += 2;
        }
        StartCoroutine(GiveHearts());

    }
}
