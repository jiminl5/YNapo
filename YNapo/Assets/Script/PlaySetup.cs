using UnityEngine;
using System.Collections;

public class PlaySetup : MonoBehaviour {
    
    public void SetPlayMode(string mode)
    {
        PlayerPrefs.SetString("PlayMode", mode); // Determine user chose single or 2 player
    }

}
