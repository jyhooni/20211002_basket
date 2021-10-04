using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class panel_sc3 : MonoBehaviour
{

    public Text HStext;

    // Start is called before the first frame update
    void Start()
    {
        HStext.text = "HIGHSCORE:" + PlayerPrefs.GetInt("HighScore");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void retry()
    {

        GameManager.I.retry();

    }

}
