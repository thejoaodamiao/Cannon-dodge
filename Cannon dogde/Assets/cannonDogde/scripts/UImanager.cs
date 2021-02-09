using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{

    [SerializeField]
    Text yourScoreText;

    [SerializeField]
    Text lifes;


    [SerializeField]
    private GameObject Enemy;

    [SerializeField]
    private Text CountText;

    public Sprite[] lives;

    [SerializeField]
    private Image lifesImage;

    private int yourScore = 0;
   
    public int  count = 3;

    private void Start()
    {
        CountText.gameObject.SetActive(true);
        StartCoroutine(CountDown());
        yourScore = 0;
    }


    private void Update()
    {
        yourScoreText.text = "Score: " + yourScore;
        CountText.text = "" + count;
     
        if (count == 0)
        {
            
            CountText.gameObject.SetActive(false);
        }
        
    }

    public IEnumerator CountDown()
    {
        while (count > 0)
        {
            
            yield return new WaitForSeconds(1.0f);
            count--;
        }
    }


    private void OnDisable()
    {
        PlayerPrefs.SetInt("Score", (int)yourScore);
    }




    public void IncreaseYourScore()
    {
        yourScore += 10;
    }

    public void UpdateLives(int currentlives)
    {
         lifesImage.sprite = lives[currentlives];

    }

}

