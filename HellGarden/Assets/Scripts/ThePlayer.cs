using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThePlayer : MonoBehaviour
{
    public static int Hears = 1;
    public Text TextHearCounter;
    public float NextPosition = 17.76f;
    public GameObject SpawnPosition;
    public GameObject NewFlower;
    public GameObject Camera;
    public int FlowerCounter = 0;
    public int FlowerCurrent = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        TextHearCounter.text = "Hears:" + Hears;

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (0 < FlowerCurrent)
            {
                FlowerCurrent -= 1;
                Camera.transform.position += new Vector3(-17.76f, 0, 0);
            }
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (FlowerCurrent < FlowerCounter)
            {
                FlowerCurrent += 1;
                Camera.transform.position += new Vector3(17.76f, 0, 0);
            }
        }
    }

    public void CreateAPlant()
    {
        Instantiate(NewFlower, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        SpawnPosition.transform.position += new Vector3(17.76f, 0, 0);
        FlowerCounter += 1;
    }


}
