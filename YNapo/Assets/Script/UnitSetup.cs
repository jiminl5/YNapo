using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitSetup : MonoBehaviour {

    public GameObject SetupUnit;

    private float startTime;
    private bool StartBattleMap;
    private bool SetupTrigger; // setup scene

    void Start()
    {
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
    }

    public void PlayerFrench()
    {
        PlayerPrefs.SetString("Player", "French");
    }

    public void PlayerAllied()
    {
        PlayerPrefs.SetString("Player", "Allied");
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
                if (obj.transform.childCount != 0)
                    obj.transform.GetChild(0).transform.eulerAngles = new Vector3(0.0f, 0.0f, 180.0f);
            }
        }
    }
}
