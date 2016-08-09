using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DefaultValue : MonoBehaviour {

    public GameObject[] DefaultObjects = new GameObject[4]; //order: 0 - French, 1 - Allied


    //UI Default
    public static Vector2 FrenchSetupDefault;
    public static Vector2 AlliedSetupDefault;


    void Awake()
    {
        //FrenchMapPos = new Vector2(DefaultObjects[0].transform.po);
    }
    // Use this for initialization
    void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
