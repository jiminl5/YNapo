using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuController : MonoBehaviour {

    public GameObject TransparentBG;

	// Update is called once per frame
	void Update () {
	    if (UnitSetup.BATTLE_STARTED)
        {
            if (TransparentBG.GetComponent<SpriteRenderer>().enabled)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
                {
                    if (obj.transform.childCount > 0 && obj.transform.GetChild(0).GetComponent<BoxCollider2D>() != null)
                    {
                        obj.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = false;
                    }
                }
            }
            else if (!TransparentBG.GetComponent<SpriteRenderer>().enabled)
            {
                foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
                {
                    if (obj.transform.childCount > 0 && obj.transform.GetChild(0).GetComponent<BoxCollider2D>() != null)
                    {
                        obj.transform.GetChild(0).GetComponent<BoxCollider2D>().enabled = true;
                    }
                }
            }
        }
	}
}
