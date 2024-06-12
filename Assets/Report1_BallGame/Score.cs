using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Score : MonoBehaviour
{
    public TMPro.TextMeshProUGUI textMeshPro;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        textMeshPro.text = "Score : " + score.ToString();
        textMeshPro.rectTransform.localScale = new Vector3(Mathf.Lerp(textMeshPro.rectTransform.localScale.x, 1, 0.1f), 1, 1);
    }

 
    public void AddToScore(int number)
    {
        score += number;
        textMeshPro.rectTransform.localScale = new Vector3 (2, 1, 1);
        //textMeshPro.
    }

}
