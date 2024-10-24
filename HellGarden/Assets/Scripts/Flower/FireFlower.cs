using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireFlower : MonoBehaviour
{

    [Header("ChangeGameObjects")]
    public Sprite Stage1;
    public Sprite Stage2;
    public Sprite Stage3;
    public SpriteRenderer sr;
    public GameObject Fire;
    [Header("Flower Health")]
    public float FlowerHealth;
    public float MaxFlowerHealth = 100;
    public float MinFlowerHealth = 0;
    public int FlowerStage;
    public float FlowerHealthLooseSpeed = 7f;
    public float IceSpeedReal = 0.2f;
    public float IceSpeed = 1f;
    [Header("OtherStates")]
    public ParticleSystem particle;
    public bool GetWater = false;
    public float LeikaPower = 14;
    public float SecondsToGetHeart = 2;
    [Header("Paricles")]
    public GameObject[] Hearts;
    public GameObject[] BroukenHearts;
    // Start is called before the first frame update


    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Ice")
        {
            IceSpeed = IceSpeedReal;
        }
        else
        {
            IceSpeed = 1;
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "FireExtinguisherCollider" && FlowerStage == 2)
        {
            GetWater = true;
        }
        if (collision.tag == "Ice")
        {
            //IceSpeed = IceSpeedReal;
        }
    }
    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "FireExtinguisherCollider")
        {
            GetWater = false;
        }
        if (collision.tag == "Ice")
        {
           IceSpeed = 1;
        }
    }
    void Start()
    {
        Fire.SetActive(false);
        sr.sprite = Stage1;
        StartCoroutine(GiveHearts());
    }

    // Update is called once per frame
    void Update()
    {
        if (GetWater == true)
        {
            FlowerHealth = MaxFlowerHealth;
        }
        if (FlowerHealth >= MinFlowerHealth && GetWater == false)
        {
            FlowerHealth -= Time.deltaTime * FlowerHealthLooseSpeed * IceSpeed;
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
            particle.Stop();
            sr.sprite = Stage1;
            Fire.SetActive(false);
        }
        else if (FlowerStage == 1)
        {
            particle.Stop();
            sr.sprite = Stage2;
            Fire.SetActive(false);
        }
        else if (FlowerStage == 2)
        {
            Fire.SetActive(true);
            sr.sprite = Stage3;
            particle.Play();
        }

    }
    private IEnumerator GiveHearts()
    {
        if (FlowerStage != 2)
        {
            yield return new WaitForSeconds(SecondsToGetHeart);
        }
        else
        {
            yield return new WaitForSeconds(0.75f);
        }
        if (FlowerStage == 2)
        {
            Instantiate(BroukenHearts[Random.Range(0, BroukenHearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears -= 1;
        }
        else if (FlowerStage == 1)
        {
            yield return new WaitForSeconds(2);
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears += 1;
        }
        else if (FlowerStage == 0)
        {
            Instantiate(Hearts[Random.Range(0, Hearts.Length)], new Vector3(transform.position.x, 0f, 0f), Quaternion.Euler(0f, 0f, 0f));
            ThePlayer.Hears += 1;
        }
        StartCoroutine(GiveHearts());

    }
}
