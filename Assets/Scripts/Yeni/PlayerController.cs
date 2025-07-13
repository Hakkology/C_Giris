using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket h�z�
    public float gravity = -9.81f; // Yer �ekimi de�eri
    public float jumpHeight = 2.0f; // Z�plama y�ksekli�i

    private CharacterController controller;
    private Vector3 velocity; // H�z vekt�r�
    private bool isGrounded; // Karakterin zeminde olup olmad���n� kontrol eder

    int walkSpeed = 4;
    int runSpeed = 7;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // CharacterController bile�enini al
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Yer �ekimi etkisini s�f�rla
        }


        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        // Karakteri hareket ettir
        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
        controller.Move(move * speed * Time.deltaTime);

        // Karakterin hareket h�z�n� hesapla (x ve z ekseninde)
        float movementSpeed = new Vector3(xMovement, 0, zMovement).magnitude;

        // Hareket durumuna g�re animasyonu de�i�tir
        if (movementSpeed == 0)
        {
            SetIdle(); // Hareketsiz durumda Idle animasyonu
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            SetRun(); // Shift tu�una bas�l�yken ve hareket ederken Run animasyonu
        }
        else
        {
            SetWalk(); // Di�er durumlarda Walk animasyonu
        }

        // Z�plama mekani�i
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SetJump();
        }

        // Yer �ekimi etkisini uygula
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // H�z vekt�r�n� kullanarak karakteri hareket ettir
    }

    private void SetWalk()
    {
        speed = walkSpeed;
    }

    private void SetRun()
    {
        speed = runSpeed;
    }

    private void SetIdle()
    {
        speed = 0;
    }

    private void SetJump()
    {
        velocity.y += Mathf.Sqrt(jumpHeight * -2f * gravity); // 
    }
}