using UnityEngine;
using System.Collections;

public class DiceRoll : MonoBehaviour {

    private bool toss;

    private float xRotation;
    private float yRotation;
    private float zRotation;
    private float roationSpeed = 15.0f;

    private float xScale;
    private float yScale;
    private float zScale;
    private float scaleSpeed = 0.03f;

    private int diceNumber;

    private string DiceName;

    void OnEnable()
    {
        DiceName = this.name.Substring(this.name.Length - 1, 1);

        toss = false;

        xRotation = this.transform.eulerAngles.x;
        yRotation = this.transform.eulerAngles.y;
        zRotation = this.transform.eulerAngles.z;

        xScale = this.transform.localScale.x;
        yScale = this.transform.localScale.y;
        zScale = this.transform.localScale.z;

        diceNumber = Random.Range(1, 7);
    }

	void Update () {
        if (this.transform.localScale.x > 0.15f)
        {   
            // Control Rotation
            xRotation += roationSpeed;
            //yRotation += 10.0f;
            zRotation += roationSpeed;
            this.transform.eulerAngles = new Vector3(xRotation, yRotation, zRotation);

            // Control Scale
            if (!toss)
            {
                xScale += scaleSpeed;
                yScale += scaleSpeed;
                zScale += scaleSpeed;
                this.transform.localScale = new Vector3(xScale, yScale, zScale);
                if (this.transform.localScale.x >= 0.7f)
                    toss = true;
            }
            else if (toss)
            {
                xScale -= scaleSpeed;
                yScale -= scaleSpeed;
                zScale -= scaleSpeed;
                this.transform.localScale = new Vector3(xScale, yScale, zScale);
                if (this.transform.localScale.x <= 0.15f)
                {
                    toss = false;
                    DiceSet();
                }
            }
        }
	}

    public void DiceReset()
    {
        this.transform.localScale = new Vector3(0.2f, 0.2f, 0.2f);
        this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
    }

    void DiceSet()
    {
        this.transform.localScale = new Vector3(0.15f, 0.15f, 0.15f);
        print("Dice " + diceNumber);
        if (diceNumber == 1)
        {
            this.transform.eulerAngles = new Vector3(0.0f, 0.0f, 0.0f);
        }
        else if (diceNumber == 2)
        {
            this.transform.eulerAngles = new Vector3(0.0f, 90.0f, 0.0f);
        }
        else if (diceNumber == 3)
        {
            this.transform.eulerAngles = new Vector3(270.0f, 0.0f, 0.0f);
        }
        else if (diceNumber == 4)
        {
            this.transform.eulerAngles = new Vector3(90.0f, 0.0f, 0.0f);
        }
        else if (diceNumber == 5)
        {
            this.transform.eulerAngles = new Vector3(0.0f, 270.0f, 0.0f);
        }
        else if (diceNumber == 6)
        {
            this.transform.eulerAngles = new Vector3(180.0f, 0.0f, 0.0f);
        }

        if (DiceName != "4")
        {
            this.transform.parent.GetChild(int.Parse(DiceName) + 1).gameObject.SetActive(true);
        }
        else 
        {
            GameObject.Find("DiceBoard").transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
