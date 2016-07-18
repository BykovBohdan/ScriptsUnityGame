using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class Score : MonoBehaviour {

    private float score = 0.0f; // на данный момент это время которое продержался игрок

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
        if (isDead)  // проверяем жив ли наш персонаж
        {
            return;
        } //end if
        if (score >= scoreToNextLevel)
        {
            SpeedUp();
        } //end if


        score += Time.deltaTime;
        scroreText.text = ((int)score).ToString(); //что бы можно было увеличивать значение чисельной переменной и отображать результат в тексте используем привидения типов с помощью метода ТуСтринг

    }

    void SpeedUp()
    {
        if (difficultyLevel == maxDifficultyLevel) //дабы скорость имела вменяемый предел
        {
            return;
        } //end if

        scoreToNextLevel *= 2; // возрастающая сложность перехода на след. скорость
        difficultyLevel += 0.05f;

        GetComponent<PlayerMotor>().SetSpeed(difficultyLevel); // обращаемся к классу игрока
    }

    public void OnDeath()
    {
        isDead = true;
        deadMenu.ToggleEndMenu(score);
    }

}
