using UnityEngine;
using System.Collections;

public class SetSortingLayer : MonoBehaviour {

    private string setSortingLayer;

	// Use this for initialization
	void Start () {
        setSortingLayer = "Dice";
        for (int i = 0; i < 6; i++)
        {
            this.transform.GetChild(i).GetComponent<MeshRenderer>().sortingLayerName = setSortingLayer;
        }
	}
}
