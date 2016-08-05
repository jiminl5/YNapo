using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UnitSetup : MonoBehaviour {

    public GameObject SetupUnit;

    private float startTime;
    private bool StartBattleMap;

    void Start()
    {
        startTime = Time.time;
    }

    public void BringSide(int side)                 //Brings the map side that user chose
    {                                               //side = 0 -> French, side = 1 -> Allied
        GameObject.Find("BattleMap").transform.GetChild(side).gameObject.SetActive(true);
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
            }

            if (SetupUnit.transform.GetChild(0).localScale.x == 1.11f
                && SetupUnit.transform.GetChild(0).eulerAngles.z == 90.0f)
            {
                StartBattleMap = false; //End Iteration
            }
        }
    }
}
