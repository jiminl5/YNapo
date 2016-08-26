using UnityEngine;
using System.Collections;

public class AlliedDeploy : MonoBehaviour
{

    public GameObject[] Allied_Units = new GameObject[4];
    //0 - Infantry, 1 - Cavalry, 2 - Artillery, 3 - Art_Horse

    private bool[] DeploySpots = new bool[]
    {false, false, false, false,
    false, false, false, false,
     false, false, false, false}; // first 4 - Left, next 4 - Center, last 4 - Right

    private bool[] DeployReserve = new bool[]
    {false, false, false, false, false}; // Reserved Spot

    public int Type; //Unit Type

    public void UnitType(int UnitType)
    {
        Type = UnitType;
    }

    public void Position(string Position)
    {
        Deploy(Type, Position);
    }

    public void Deploy(int UnitType, string Position) // order 0 - 2 - 1 - 3
    {
        int i = 0;
        if (Position == "Allied_C")
        {
            i = 4;
        }
        else if (Position == "Allied_R")
        {
            i = 8;
        }

        if (!DeploySpots[i + 0])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find(Position).transform.GetChild(0).position.x,
            GameObject.Find(Position).transform.GetChild(0).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find(Position).transform.GetChild(0);
            //GameObject.Find(Position).transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            DeploySpots[i + 0] = true;
        }
        else if (!DeploySpots[i + 2])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find(Position).transform.GetChild(2).position.x,
            GameObject.Find(Position).transform.GetChild(2).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find(Position).transform.GetChild(2);
            DeploySpots[i + 2] = true;
        }
        else if (!DeploySpots[i + 1])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find(Position).transform.GetChild(1).position.x,
            GameObject.Find(Position).transform.GetChild(1).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find(Position).transform.GetChild(1);
            DeploySpots[i + 1] = true;
        }
        else if (!DeploySpots[i + 3])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find(Position).transform.GetChild(3).position.x,
            GameObject.Find(Position).transform.GetChild(3).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find(Position).transform.GetChild(3);
            DeploySpots[i + 3] = true;
        }
    }

    public void Deploy_Reserved(int UnitType)
    {
        if (!DeployReserve[0])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find("Allied_Res").transform.GetChild(0).position.x,
            GameObject.Find("Allied_Res").transform.GetChild(0).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find("Allied_Res").transform.GetChild(0);
            GameObject.Find("Allied_Res").transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
            DeployReserve[0] = true;
        }
        else if (!DeployReserve[1])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find("Allied_Res").transform.GetChild(1).position.x,
            GameObject.Find("Allied_Res").transform.GetChild(1).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find("Allied_Res").transform.GetChild(1);
            GameObject.Find("Allied_Res").transform.GetChild(1).GetComponent<SpriteRenderer>().enabled = false;
            DeployReserve[1] = true;
        }
        else if (!DeployReserve[2])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find("Allied_Res").transform.GetChild(2).position.x,
            GameObject.Find("Allied_Res").transform.GetChild(2).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find("Allied_Res").transform.GetChild(2);
            GameObject.Find("Allied_Res").transform.GetChild(2).GetComponent<SpriteRenderer>().enabled = false;
            DeployReserve[2] = true;
        }
        else if (!DeployReserve[3])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find("Allied_Res").transform.GetChild(3).position.x,
            GameObject.Find("Allied_Res").transform.GetChild(3).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find("Allied_Res").transform.GetChild(3);
            GameObject.Find("Allied_Res").transform.GetChild(3).GetComponent<SpriteRenderer>().enabled = false;
            DeployReserve[3] = true;
        }
        else if (!DeployReserve[4])
        {
            GameObject temp = (GameObject)Instantiate(Allied_Units[UnitType], new Vector2(
            GameObject.Find("Allied_Res").transform.GetChild(4).position.x,
            GameObject.Find("Allied_Res").transform.GetChild(4).position.y), Quaternion.identity);
            temp.transform.parent = GameObject.Find("Allied_Res").transform.GetChild(4);
            GameObject.Find("Allied_Res").transform.GetChild(4).GetComponent<SpriteRenderer>().enabled = false;
            DeployReserve[4] = true;
        }
    }
}
