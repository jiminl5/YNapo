using UnityEngine;
using System.Collections;

public class UnitPosition : MonoBehaviour {

    public GameObject positionSpot;
    public GameObject positionReserve;

    private int maxSpotX;
    private int maxSpotY;

    private float reserveTmp;
	// Use this for initialization
	void Start () {
        maxSpotX = 2;
        maxSpotY = 2;

        GenerateSpots();
    }

    public void GenerateSpots()
    {
        // Units - L C R
        for (int i = maxSpotX - 1; i >= 0; i--)
        {
            for (int j = 0; j < maxSpotY; j++)
            {
                //**French Position Spots************
                GameObject French_L = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                French_L.transform.parent = GameObject.Find("French_L").transform;
                French_L.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));

                GameObject French_C = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                French_C.transform.parent = GameObject.Find("French_C").transform;
                French_C.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));

                GameObject French_R = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                French_R.transform.parent = GameObject.Find("French_R").transform;
                French_R.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));

                //**Allied Position Spots************
                GameObject Allied_L = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                Allied_L.transform.parent = GameObject.Find("Allied_L").transform;
                Allied_L.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));

                GameObject Allied_C = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                Allied_C.transform.parent = GameObject.Find("Allied_C").transform;
                Allied_C.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));

                GameObject Allied_R = (GameObject)Instantiate(positionSpot, new Vector2(i, (float)(i - (j * 2 + 0.5f))), Quaternion.identity);
                Allied_R.transform.parent = GameObject.Find("Allied_R").transform;
                Allied_R.transform.localPosition = new Vector2(i, (float)(i - (j * 2 + 0.5f)));
            }
        }
        //Units - Reserved
        for (int i = 0; i < 5; i++)
        {
            reserveTmp = ((Mathf.Pow(-1.0f, i) * 1.5f) * i) + reserveTmp;
            GameObject French_Res = (GameObject)Instantiate(positionReserve, new Vector2(reserveTmp, -3.3f), Quaternion.identity);
            French_Res.transform.parent = GameObject.Find("French_Res").transform;
            French_Res.transform.localPosition = new Vector2(reserveTmp, -3.3f);

            GameObject Allied_Res = (GameObject)Instantiate(positionReserve, new Vector2(reserveTmp, -3.3f), Quaternion.identity);
            Allied_Res.transform.parent = GameObject.Find("Allied_Res").transform;
            Allied_Res.transform.localPosition = new Vector2(reserveTmp, -3.3f);
        }

    }
}
