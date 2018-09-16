using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeeterBar : MonoBehaviour {
    float scale;
    float init;
    Shield s;
	// Use this for initialization
	void Start () {
        scale = transform.localScale.x;
        s = Player.Instance.gameObject.transform.GetChild(0).GetComponent<Shield>();
        init = s.reflectMeeter;
	}
    // Update is called once per frame
    void Update () {
        float frac = s.reflectMeeter / init;
        transform.localScale = new Vector3(scale * frac, transform.localScale.y, transform.localScale.z);
        GetComponent<Image>().color = new Color(1f, frac, frac, .7f);
	}
}
