using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    private float score = 0.0f; // переменная хранящая очки(или время)

    public Text scroreText;

    private float difficultyLevel = 0.5f;
    private float maxDifficultyLevel = 2.0f;
    private int scoreToNextLevel = 10;
    private bool isDead = false;

    public DeadMenu deadMenu;
	// Use this for initialization
	void Start () {
       // scroreText.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            return;
        }
        if (score >= scoreToNextLevel)
        {
            SpeedUp();
        }


        score += Time.deltaTime;
        scroreText.text = ((int)score).ToString(); //что бы можно было увеличивать значение чисельной переменной и отображать результат в тексте используем привидения типов с помощью метода ТуСтринг

    }

    void SpeedUp()
    {
        if (difficultyLevel == maxDifficultyLevel)
        {
            return;
        }

        scoreToNextLevel *= 2; // каждый переход сложнее;
        difficultyLevel += 0.05f;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel);
    }

    public void OnDeath()
    {
        isDead = true;
        deadMenu.ToggleEndMenu(score);
    }

}
