using UnityEngine;
using System.Collections;

public class CancelMenu : MonoBehaviour {

    public void CancelButton()
    {
        GameObject.Find("Transparent_bg").GetComponent<SpriteRenderer>().enabled = false;
        this.transform.parent.GetComponent<BringMenu>().DefaultSelection();
    }
}
