//Меню после смерти
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class DeadMenu : MonoBehaviour {

    public Text scoreText;
	// Use this for initialization
	void Start () {
        gameObject.SetActive(false); //скрыть обькт
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    public void ToggleEndMenu (float score)
    {
        gameObject.SetActive(true);
        scoreText.text = ((int)score).ToString();
    }

    public void Restart ()
    {
     //   SceneManager.UnloadScene(SceneManager.GetActiveScene().name);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // хитрая конструкция для вызова текущей сцены без явного указания имени
    }
    public void Menu()
    {
        SceneManager.LoadScene("menu");
    }

}
