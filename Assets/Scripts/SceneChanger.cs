using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour {
    [SerializeField] int level = 1;
    public int NumToKill = 1;
	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ChangeLevel(string Level)
    {
        SceneManager.LoadScene("Victory");
    }

    public void CheckLevelOver()
    {
        if (NumToKill <= 0)
        {
            SceneManager.LoadScene("Level" + level);
        }
    }

}
