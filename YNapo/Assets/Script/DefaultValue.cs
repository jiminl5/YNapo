using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DefaultValue : MonoBehaviour {

    public static List<Queue<GameObject>> unit_queue = new List<Queue<GameObject>>();
    public static Queue<GameObject> unit_ready = new Queue<GameObject>();

    public void DefaultSelection()
    {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
        {
            if (obj.transform.childCount > 0 && obj.transform.GetChild(0).childCount > 1)
            {
                obj.transform.GetChild(0).GetComponent<BringMenu>().selected = false;
                if (obj.transform.GetChild(0).name.StartsWith("A"))
                    obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                else if (obj.transform.GetChild(0).name.StartsWith("F"))
                    obj.transform.GetChild(0).GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            }
        }
    }
}
