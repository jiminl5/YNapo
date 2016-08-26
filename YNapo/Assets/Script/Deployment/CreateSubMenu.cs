using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CreateSubMenu : MonoBehaviour {

    public GameObject subMenu;

	void Start () {
        if (this.name.StartsWith("F"))
        {
            GameObject subMenu_ = (GameObject)Instantiate(subMenu, new Vector2(0.0f, 0.0f), Quaternion.identity);
            subMenu_.transform.SetParent(this.transform, false);
        }
        else if (this.name.StartsWith("A"))
        {
            GameObject subMenu_ = (GameObject)Instantiate(subMenu, new Vector2(0.0f, 0.0f), Quaternion.Euler(0.0f, 0.0f, 180.0f));
            subMenu_.transform.SetParent(this.transform, false);
        }
    }
}
