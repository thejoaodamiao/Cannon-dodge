using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIgameOver : MonoBehaviour
{
    [SerializeField]
    private Text yourScoreText;

    private int yourScore = 0;

    

    // Start is called before the first frame update
    void Start()
    {
        yourScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        yourScoreText.text ="Score: " + PlayerPrefs.GetInt("Score");
    }

}
