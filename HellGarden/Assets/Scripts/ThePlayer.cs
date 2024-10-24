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
    public GameObject[] AllFllowersTypes;
    public GameObject NextFlower1;
    public GameObject NextFlower2;
    public GameObject ChoosedFlower;
    [Header("ObjectsForPlayer")]
    public Text TextHearCounter;
    public Text TextMaxHear;
    public Text TextNextHears;
    public Text PlantToChoose1;
    public Text PlantToChoose2;
    public GameObject SpawnPosition;
    public GameObject Camera;
    public GameObject WallRigght;
    public GameObject ToSpawnDArrowCoordinats;
    public GameObject DArrow;
    [Header("ObjectsForPlayer")]
    public GameObject ChooseFlowersPanel;
    public GameObject DeadPanel;
    public GameObject StopPanel;
    public GameObject NextHearsPanel;
    public GameObject AllPlants;
    [Header("PlantsDescriptions")]
    public string BlackHoleDescription;
    public string FrogDescription;
    public string TomatoDescription;
    public string FireDescription;
    // Start is called before the first frame update
    void Start()
    {
        NextHearsPanel.SetActive(true);
        StopPanel.SetActive(false);
        ChooseFlowersPanel.SetActive(false);
        DeadPanel.SetActive(false);
        AllPlants.SetActive(false);
        FindDublicity();
        NextFlower1 = AllFllowers[Random.Range(0, AllFllowers.Count)];
        NextFlower2 = AllFllowers[Random.Range(0, AllFllowers.Count)];
        FindThePlant1();
        FindThePlant2();
    }

    // Update is called once per frame
    void Update()
    {
        if (AllFllowers.Count < 1)
        {
            NextHearsPanel.SetActive(false);
            AllPlants.SetActive(true);
            ChooseFlowersPanel.SetActive(false);
        }
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

        if (Input.GetKeyDown(KeyCode.P))
        {
            Hears += 5;
        }
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
    public void FindThePlant1()
    {
        if (NextFlower1 == AllFllowersTypes[0])
        {
            PlantToChoose1.text = BlackHoleDescription;
        }
        else if (NextFlower1 == AllFllowersTypes[1])
        {
            PlantToChoose1.text = FrogDescription;
        }
        else if (NextFlower1 == AllFllowersTypes[2])
        {
            PlantToChoose1.text = TomatoDescription;
        }
        else if (NextFlower1 == AllFllowersTypes[3])
        {
            PlantToChoose1.text = FireDescription;
        }
    }
    public void FindThePlant2()
    {
        if (NextFlower2 == AllFllowersTypes[0])
        {
            PlantToChoose2.text = BlackHoleDescription;
        }
        else if (NextFlower2 == AllFllowersTypes[1])
        {
            PlantToChoose2.text = FrogDescription;
        }
        else if (NextFlower2 == AllFllowersTypes[2])
        {
            PlantToChoose2.text = TomatoDescription;
        }
        else if (NextFlower2 == AllFllowersTypes[3])
        {
            PlantToChoose2.text = FireDescription;
        }
    }

    public void CreateAPlant1()
    {
        Time.timeScale = 1f;
        Instantiate(NextFlower1, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(DArrow, new Vector3(ToSpawnDArrowCoordinats.transform.position.x, ToSpawnDArrowCoordinats.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        SpawnPosition.transform.position += new Vector3(17.76f, 0, 0);
        FlowerCounter += 1;
        ChoosedFlower = NextFlower1;
        FindDublicity();
        ChooseFlowersPanel.SetActive(false);
        WallRigght.transform.position += new Vector3(17.76f, 0, 0);
        FindThePlant1();
        FindThePlant2();
    }
    public void CreateAPlant2()
    {
        Time.timeScale = 1f;
        Instantiate(NextFlower2, new Vector3(SpawnPosition.transform.position.x, SpawnPosition.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        Instantiate(DArrow, new Vector3(ToSpawnDArrowCoordinats.transform.position.x, ToSpawnDArrowCoordinats.transform.position.y, 0f), Quaternion.Euler(0f, 0f, 0f));
        SpawnPosition.transform.position += new Vector3(17.76f, 0, 0);
        FlowerCounter += 1;
        ChoosedFlower = NextFlower2;
        FindDublicity();
        ChooseFlowersPanel.SetActive(false);
        WallRigght.transform.position += new Vector3(17.76f, 0, 0);
        FindThePlant1();
        FindThePlant2();
    }

    public void FindDublicity()
    {
        if (AllFllowers.Count >= 1)
        {
            for (int i = 0; i < AllFllowers.Count; i++)
            {
                if (AllFllowers[i] == ChoosedFlower)
                {
                    AllFllowers.Remove(AllFllowers[i]);
                }
            }
            NextFlower1 = AllFllowers[Random.Range(0, AllFllowers.Count)];
            NextFlower2 = AllFllowers[Random.Range(0, AllFllowers.Count)];
        }
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
