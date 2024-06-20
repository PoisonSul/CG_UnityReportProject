using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using TMPro;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class GameMAnager : MonoBehaviour
{
    public int live = 3;
    private int addScoreInterval = 1;
    private double score = 0;
    [SerializeField] TextMeshProUGUI scoreText;
    private bool onNotice = false;
    private bool crashed = false;
    [SerializeField] GameObject player;

    [SerializeField] TextMeshProUGUI GOText;
    [SerializeField] GameObject GOPanel;


    public static GameMAnager Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        AddScore();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void UseLive()
    {
        if (live >= 0 && !crashed)
        {
            crashed = true;
            --live;
            await Task.Delay(500);
            crashed = false;
        }

        if(live == 0)
        {
            SpeedManager.Instance.StopNow();
            Destroy(player);

            GOPanel.gameObject.SetActive(true);
            scoreText.gameObject.SetActive(false);
            GOText.text = "<color=green>점수 : " + score.ToString() + "</color>";
        }
    }

    async void AddScore()
    {
        while (live > 0)
        {
            await Task.Delay(addScoreInterval * 500);
            ++score;
            updateText();
        }
    }
    //public void BonusOn(bool On = true)
    //{
    //    BonusScore(On);
    //}
    //async void BonusScore(bool On = true)
    //{
        
    //}

    private void updateText()
    {
        if (score % 20 == 0 & !onNotice)
        {
            ScoreHighlight();
        }
        else if(!onNotice)
        {
            scoreText.text = "점수 : " + score.ToString();
        }
    }

    async void ScoreHighlight()
    {
        onNotice = true;
        scoreText.text = "<color=red>점수 : " + score.ToString() + "</color>";
        await Task.Delay(1000);
        onNotice = false;
        scoreText.text = "점수 : " + score.ToString();
    }
}
