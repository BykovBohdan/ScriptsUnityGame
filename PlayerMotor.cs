using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMotor : MonoBehaviour {
    
    private Animator anaimationJump;

    public Text powerText;
    private float power = 0.0f;
    private CharacterController controller;
    public float speed = 2.0f; // в коде не используют значения
    private Vector3 moveVector; // создаю новый вектор для движение героя, книга стр.55
    private float varticalVelocity = 0.0f; // переменная для гравитации, падение
    private float animationDuration = 3.0f;
    private float gravity = 9.8f; //
    public float jumpForce = 2.1f;
    public Text textGo;

    private bool isDead = false;
	// Use this for initialization
	void Start () {
        controller = GetComponent <CharacterController> (); //  контроллера исп. для управление от первого или 3-го лица где не нужна физика
        anaimationJump = GetComponent<Animator>();
        textGo.text = "Ready?";
        
    }
	
	// Update is called once per frame
	void Update () {
        if (isDead)
        {
            return;
        }
        
      if (Time.time < animationDuration)
        {
            
            controller.Move(Vector3.forward * speed * Time.deltaTime);
          
            return;
        }
        textGo.text = " ";
        if (controller.isGrounded && Input.GetKeyDown(KeyCode.Space)) // если контроллер на земле 
        {

           
            varticalVelocity = jumpForce;

          
            
                anaimationJump.SetBool("Jump", true);
            //  
          

        }
        else // в противном случае в каждом кадре отнимаем результат операции чем изменяем положение обьекта
        {
            
            anaimationJump.SetBool("Jump", false);
            varticalVelocity -= gravity * Time.deltaTime;
        }
        moveVector = Vector3.zero; // вместе записи вектор(0,0,0) 

        //x left&right
        moveVector.x = Mathf.Clamp(Input.GetAxis("Horizontal"), -1, 1);  // считываем значение с управляющих кнопок
       
        //y up&down
        moveVector.y = varticalVelocity; // гравитация
        //z forward&back
        moveVector.z = speed; // ранер же, постоянный прирост вперед

        controller.Move(moveVector * Time.deltaTime); // движение контроллера 
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "crystal")
        {
            Destroy(other.gameObject);
            power += 1;
            powerText.text = "x " + ((int)power).ToString();
            
        }
            //  other.gameObject.SetActive(false);
           
       // через свич зделать разные варианты смертей от лазеров
        else {

            Death();
        }


    }

    public void SetSpeed(float modifier)
    {
        speed += modifier;
    }
     // hero hit
   /* private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.point.z > transform.position.z + controller.radius)
        {
            if (laser.tag == "laser")
            {
                Death();
            }
        }
            


    } */

    private void Death()
    {
        isDead = true;
        GetComponent<Score>().OnDeath();
    }
}
