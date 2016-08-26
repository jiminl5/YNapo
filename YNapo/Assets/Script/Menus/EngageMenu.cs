using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class EngageMenu : MonoBehaviour {

    private GameObject DeterminePos;
    private GameObject[] enemies = new GameObject[3];
    private int childCount = 0;

    void Start()
    {
        DeterminePos = this.transform.parent.parent.parent.gameObject;
        if (DeterminePos.name.StartsWith("A"))
        {
            enemies[0] = GameObject.Find("French_L");
            enemies[1] = GameObject.Find("French_C");
            enemies[2] = GameObject.Find("French_R");
        }
        else if (DeterminePos.name.StartsWith("F"))
        {
            enemies[0] = GameObject.Find("Allied_L");
            enemies[1] = GameObject.Find("Allied_C");
            enemies[2] = GameObject.Find("Allied_R");
        }
    }
    

    public void DoAction()
    {
        if (this.transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("Engage"))
        {
            if(this.name.StartsWith("A"))
                this.transform.parent.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
            else if (this.name.StartsWith("F"))
                this.transform.parent.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 1.0f, 1.0f);
            TargetEnemy();
        }
        else if (this.transform.GetChild(0).GetComponent<Image>().sprite.name.Contains("Fire"))
        {
            //Bring Dice
            GameObject.Find("DiceArray").transform.GetChild(
            GameObject.Find("DiceArray").transform.childCount - 1).gameObject.SetActive(true);
            GameObject.Find("DiceArray").transform.GetChild(1).gameObject.SetActive(true);
        }
    }
    /* 
        Allied L targets French R
        Allied R targets French L
        Center targets Center
    */
    void TargetEnemy()
    {
        int getEnemy = 0;
        PlayerPrefs.SetInt("EngageMode", 1);
        if ((DeterminePos.name.StartsWith("A") || DeterminePos.name.StartsWith("F"))
            && DeterminePos.name.Substring(DeterminePos.name.Length - 1, 1) == "L") // If parent game object shows the position is Allied Left
        {
            getEnemy = 2;
        }

        else if ((DeterminePos.name.StartsWith("A") || DeterminePos.name.StartsWith("F"))
            && DeterminePos.name.Substring(DeterminePos.name.Length - 1, 1) == "C")
        {
            getEnemy = 1;
        }
        else if ((DeterminePos.name.StartsWith("A") || DeterminePos.name.StartsWith("F"))
            && DeterminePos.name.Substring(DeterminePos.name.Length - 1, 1) == "R")
        {
            getEnemy = 0;
        }
        
        this.transform.parent.GetComponent<BringMenu>().Engaged = true; //Proto-code for Engage

        GlowEnemies(getEnemy);

        if (childCount >= 4)
        {
            print("Nothing to Engage");
            this.transform.parent.GetComponent<BringMenu>().Engaged = false;
            this.transform.parent.GetComponent<BringMenu>().selected = false;
            this.transform.parent.GetComponent<BringMenu>().ChangeButtonImg();
            this.transform.parent.GetComponent<BringMenu>().DefaultSelection();
            PlayerPrefs.SetInt("EngageMode", 0);
        }
        childCount = 0;
    }

    void GlowEnemies(int getEnemy)
    {
        foreach (Transform child in enemies[getEnemy].transform)
        {
            if (child.childCount > 0 && child.GetChild(0).childCount > 1) // child = position (Clone)
            {
                child.GetChild(0).GetComponent<BringMenu>().selected = true;
            }
            else if (child.childCount == 0)
            {
                childCount += 1;
            }
            GameObject.Find("Transparent_bg").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
