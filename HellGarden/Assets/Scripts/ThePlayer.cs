using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ThePlayer : MonoBehaviour
{
    [Header("PlayerStats")]
    public static int Hears = 1;
    public int MaxHealth = 1;
    public float NextPosition = 17.76f;
    public int FlowerCounter = 0;
    public int FlowerCurrent = 0;
    public int HeartsThatPlayerNeed = 20;
    public int[] HeartsThatPlayerNeedList;
    private int HeartsThatPlayerNeedNow = 0;
    private bool IsGameStoped = false;
    [Header("Flowers")]
    public List<GameObject> AllFllowers;
    public GameObject NextFlower1;
    public GameObject NextFlower2;
    public GameObject ChoosedFlower;
    [Header("ObjectsForPlayer")]
    public Text TextHearCounter;
    public Text TextMaxHear;
    public Text TextNextHears;
    public GameObject SpawnPosition;
    public GameObject Camera;
    public GameObject WallRigght;
    [Header("ObjectsForPlayer")]
    public GameObject ChooseFlowersPanel;
    public GameObject DeadPanel;
    public GameObject StopPanel;
    public GameObject NextHearsPanel;
    // Start is called before the first frame update
    void Start()
    {
        NextHearsPanel.SetActive(true);
        StopPanel.SetActive(false);
        ChooseFlowersPanel.SetActive(false);
        DeadPanel.SetActive(false);
        FindDublicity();
        NextFlower1 = AllFllowers[Random.Range(0, AllFllowers.Count)];
        NextFlower2 = AllFllowers[Random.Range(0, AllFllowers.Count)];
    }

    // Update is called once per frame
    void Update()
    {
        if (Hears > MaxHealth)
        {
            MaxHealth = Hears;
        }
        if (Hears <= 0)
        {
            DeadPanel.SetActive(true);
        }


        if (Hears >= HeartsThatPlayerNeed && FlowerCounter < 4)
        {
            Time.timeScale = 0f;
            HeartsThatPlayerNeedNow += 1;
            HeartsThatPlayerNeed = HeartsThatPlayerNeedList[HeartsThatPlayerNeedNow];
            ChooseFlowersPanel.SetActive(true);
        }

        TextNextHears.text = "" + HeartsThatPlayerNeed;
        TextMaxHear.text = "" + MaxHealth;
        TextHearCounter.text = " " + Hears;

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
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsGameStoped == false)
            {
                Time.timeScale = 0f;
                IsGameStoped = true;
                StopPanel.SetActive(true);
            }
            else
            {
                Time.timeScale = 1f;
                IsGameStoped = false;
                StopPanel.SetActive(false);
            }
        }
    }

    public void CreateAPlant1()
    {
        Time.timeScale = 1f;
        Instantiate(NextFlower1, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        SpawnPosition.transform.position += new Vector3(17.76f, 0, 0);
        FlowerCounter += 1;
        ChoosedFlower = NextFlower1;
        FindDublicity();
        ChooseFlowersPanel.SetActive(false);
        WallRigght.transform.position += new Vector3(17.76f, 0, 0);
    }
    public void CreateAPlant2()
    {
        Time.timeScale = 1f;
        Instantiate(NextFlower2, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        SpawnPosition.transform.position += new Vector3(17.76f, 0, 0);
        FlowerCounter += 1;
        ChoosedFlower = NextFlower2;
        FindDublicity();
        ChooseFlowersPanel.SetActive(false);
        WallRigght.transform.position += new Vector3(17.76f, 0, 0);
    }

    public void FindDublicity()
    {
        for (int i =0;i < AllFllowers.Count; i++)
        {
            if (AllFllowers[i] == ChoosedFlower)
            {
                AllFllowers.Remove(AllFllowers[i]);
            }
        }
        NextFlower1 = AllFllowers[Random.Range(0, AllFllowers.Count)];
        NextFlower2 = AllFllowers[Random.Range(0, AllFllowers.Count)];
    }


    public void RestartClick()
    {
        Hears = 1;
        ChooseFlowersPanel.SetActive(false);
        SceneManager.LoadScene("SampleScene");
        Time.timeScale = 1f;
    }

    public void RestartExit()
    {
        Hears = 1;
        ChooseFlowersPanel.SetActive(false);
        SceneManager.LoadScene("MainMenu");
        Time.timeScale = 1f;
    }
    public void ReturnToTheGame()
    {
        IsGameStoped = false;
        StopPanel.SetActive(false);
        Time.timeScale = 1f;
    }

}
