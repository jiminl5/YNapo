using UnityEngine;
using System.Collections;

public class UnitPosition : MonoBehaviour {

    public GameObject positionSpot;

    private int maxSpotX;
    private int maxSpotY;

	// Use this for initialization
	void Start () {
        maxSpotX = 2;
        maxSpotY = 2;

        GenerateSpots();
    }

    public void GenerateSpots()
    {
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
    }
}
