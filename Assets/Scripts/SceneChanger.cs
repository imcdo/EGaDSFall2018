using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    public int NumToKill = 1;
    [SerializeField] string lvl;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeLevel(string Level)
    {
        SceneManager.LoadScene(Level);
    }

    public void CheckLevelOver()
    {
        NumToKill--;
        if (NumToKill <= 0)
        {
            SceneManager.LoadScene(lvl);
        }
    }

}
