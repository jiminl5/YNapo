using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitSetup : MonoBehaviour {

    public GameObject SetupUnit;

    private float startTime;
    private bool StartBattleMap;
    private bool SetupTrigger; // setup scene

    private int playerCount;

    public static bool UNIT_SELECTED;
    public static bool BATTLE_STARTED;

    void Start()
    {
        UNIT_SELECTED = false;
        BATTLE_STARTED = false;
        playerCount = 0;
        startTime = Time.time;
        SetupTrigger = false;
    }

    public void BringSide(int side)                 //Brings the map side that user chose
    {                                               //side = 0 -> French, side = 1 -> Allied
        GameObject.Find("BattleMap").transform.GetChild(side).GetComponent<SpriteRenderer>().enabled = true;
        SetupUnit.transform.GetChild(side).gameObject.SetActive(true);
    }

    void StartButton()
    {
        //If all the units are setted up - Activate Start Button
    }

    public void StartBattle() //Called when 'Start' button is pressed
    {
        if (PlayerPrefs.GetString("Player") == "French" && playerCount < 2)
        {
            if (playerCount == 0)
            {
                GameObject.FindGameObjectWithTag("FrenchBattleMap").SetActive(false);
                GameObject.FindGameObjectWithTag("FrenchSetup").SetActive(false);
                BringSide(1);
            }
            playerCount += 1;
        }
        else if (PlayerPrefs.GetString("Player") == "Allied" && playerCount < 2)
        {
            if (playerCount == 0)
            {
                GameObject.FindGameObjectWithTag("AlliedBattleMap").SetActive(false);
                GameObject.FindGameObjectWithTag("AlliedSetup").SetActive(false);
                BringSide(0);
            }
            playerCount += 1;
        }

        if (playerCount == 2) {
            foreach (Transform child in GameObject.Find("BattleMap").transform)
            {
                child.gameObject.SetActive(true);
            }

            foreach (Transform child in SetupUnit.transform)
            {
                child.gameObject.SetActive(false);
            }

            StartBattleMap = true;
            SetupTrigger = false;

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
            {
                obj.transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);
                if (obj.transform.childCount != 0)
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            }

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("ReserveSpot"))
            {
                obj.transform.localScale += new Vector3(0.0f, 0.1f, 0.0f);
                if (obj.transform.childCount != 0)
                {
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
                    obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder - 1;
                }
            }

            HideUnits(); // Hidden Units
            BATTLE_STARTED = true;
        }
    }

    public void PlayerFrench()
    {
        PlayerPrefs.SetString("Player", "French");
    }

    public void PlayerAllied()
    {
        PlayerPrefs.SetString("Player", "Allied");
    }

    public void HideUnits()
    {
        if (PlayerPrefs.GetString("Player") == "French") // Chosen Defender
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
            {
                if (obj.transform.childCount > 0 && obj.transform.GetChild(0).name.StartsWith("F")) // if Defender is French, then reveal Allied
                {
                    obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder - 1;
                }
            }
        }
        else if (PlayerPrefs.GetString("Player") == "Allied") // Chosen Defender
        {
            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
            {
                if (obj.transform.childCount > 0 && obj.transform.GetChild(0).name.StartsWith("A")) // if Defender is Allied, then reveal French
                {
                    obj.transform.GetChild(0).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder =
                        obj.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder - 1;
                }
            }
        }
    }

    void Update()
    {
        if (StartBattleMap)
        {
            foreach (Transform child in GameObject.Find("BattleMap").transform)
            {
                child.gameObject.SetActive(true);
                child.localScale = Vector2.Lerp(child.localScale, new Vector2(1.11f, 1.11f), (Time.time - startTime) * 0.05f);
                float angle;
                float target;
                if (child.gameObject.tag == "FrenchBattleMap")
                {
                    target = -90f;
                    angle = Mathf.MoveTowardsAngle(child.eulerAngles.z, target, 150.0f * Time.deltaTime);
                    child.eulerAngles = new Vector3(0.0f, 0.0f, angle);
                }
                if (child.gameObject.tag == "AlliedBattleMap")
                {
                    target = 90f;
                    angle = Mathf.MoveTowardsAngle(child.eulerAngles.z, target, 150.0f * Time.deltaTime);
                    child.eulerAngles = new Vector3(0.0f, 0.0f, angle);
                }

                if (child.eulerAngles.z == 270.0f || child.eulerAngles.z == 90.0f)
                {
                    child.localScale = new Vector2(1.11f, 1.11f);
                    StartBattleMap = false; // End of Iteration
                    SetupTrigger = true;
                    Screen.autorotateToPortrait = true;
                }
            }
        }

        //Screen Orientation
        if (Input.deviceOrientation == DeviceOrientation.Portrait && SetupTrigger)
        {
            GameObject.Find("BattleMap").transform.localScale = new Vector2(0.56f, 0.56f);
            if (PlayerPrefs.GetString("Player") == "French")
            {
                GameObject.Find("BattleMap").transform.eulerAngles = new Vector3(0.0f, 0.0f, 90.0f);
            }
            else if (PlayerPrefs.GetString("Player") == "Allied")
            {
                GameObject.Find("BattleMap").transform.eulerAngles = new Vector3(0.0f, 0.0f, 270.0f);
            }

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
            {
                if (obj.transform.childCount != 0)
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
            }
        }
        else if ((Input.deviceOrientation == DeviceOrientation.LandscapeLeft ||
        Input.deviceOrientation == DeviceOrientation.LandscapeRight) && SetupTrigger)
        {
            GameObject.Find("BattleMap").transform.localScale = new Vector2(1.0f, 1.0f);
            GameObject.Find("BattleMap").transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);

            foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
            {
                if (obj.transform.childCount != 0 && obj.transform.parent.name.StartsWith("F"))
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
                else if (obj.transform.childCount != 0 && obj.transform.parent.name.StartsWith("A"))
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            }
        }
    }
}
