using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BringMenu : MonoBehaviour {

    private float colorGlow;

    public bool selected;
    private bool glow;
    //private int selectedCount;

    private float glowSpeed = 10.0f;

    public bool Engaged;

    public Sprite[] buttonImg = new Sprite[2];

    void Start()
    {
        selected = false;
        //selectedCount = 0;
        glow = false;
        colorGlow = 255.0f;
    }

    void OnMouseDown()
    {
        if (UnitSetup.BATTLE_STARTED)
        {
            if (this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder >
                this.GetComponent<SpriteRenderer>().sortingOrder && !selected
                && PlayerPrefs.GetInt("EngageMode") == 0)
            {
                DefaultSelection();
                selected = true;
            }
            else if (this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder >
                this.GetComponent<SpriteRenderer>().sortingOrder && selected
                && PlayerPrefs.GetInt("EngageMode") == 0)
            {
                this.transform.GetChild(1).gameObject.SetActive(true);
                //Switch source image for button
                ChangeButtonImg();
                GameObject.Find("Transparent_bg").GetComponent<SpriteRenderer>().enabled = true;
                selected = false;
            }
            else if (PlayerPrefs.GetInt("EngageMode") == 1 && selected)
            {
                DefaultSelection();
                Engaged = true;
                this.transform.GetChild(0).GetComponent<SpriteRenderer>().sortingOrder += 2;
                PlayerPrefs.SetInt("EngageMode", 0);
            }
        }
    }

    public void ChangeButtonImg()
    {
        if (!Engaged)
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buttonImg[0];
        }
        else if (Engaged)
        {
            this.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = buttonImg[1];
        }
    }

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

    /*
    void SelectedUnit()
    {
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("PositionSpot"))
        {
            if (obj.transform.childCount > 0)
            {
                selectedCount = 0;
                if (obj.transform.GetChild(0).GetComponent<BringMenu>().selected)
                    selectedCount += 1;
            }
        }
    }
    */
    void Update()
    {
        if (selected)
        {
            if (!glow)
            {
                colorGlow -= glowSpeed;
                if (colorGlow < 10.0f)
                    glow = true;
            }
            else if (glow)
            {
                colorGlow += glowSpeed;
                if (colorGlow >= 255.0f)
                    glow = false;
            }
            if (this.transform.name.StartsWith("A"))
                this.GetComponent<SpriteRenderer>().color = new Color(colorGlow / 255.0f, 0.0f, 0.0f, 1.0f);
            else if (this.transform.name.StartsWith("F"))
                this.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, colorGlow / 255.0f, 1.0f);
        }
    }
}
