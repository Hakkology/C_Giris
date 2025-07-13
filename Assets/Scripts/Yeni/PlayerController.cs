using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Karakterin hareket hýzý
    public float gravity = -9.81f; // Yer çekimi deðeri
    public float jumpHeight = 2.0f; // Zýplama yüksekliði

    private CharacterController controller;
    private Vector3 velocity; // Hýz vektörü
    private bool isGrounded; // Karakterin zeminde olup olmadýðýný kontrol eder

    int walkSpeed = 4;
    int runSpeed = 7;

    void Start()
    {
        controller = GetComponent<CharacterController>(); // CharacterController bileþenini al
    }

    void Update()
    {
        isGrounded = controller.isGrounded;
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = 0f; // Yer çekimi etkisini sýfýrla
        }


        float xMovement = Input.GetAxis("Horizontal");
        float zMovement = Input.GetAxis("Vertical");

        // Karakteri hareket ettir
        Vector3 move = transform.right * xMovement + transform.forward * zMovement;
        controller.Move(move * speed * Time.deltaTime);

        // Karakterin hareket hýzýný hesapla (x ve z ekseninde)
        float movementSpeed = new Vector3(xMovement, 0, zMovement).magnitude;

        // Hareket durumuna göre animasyonu deðiþtir
        if (movementSpeed == 0)
        {
            SetIdle(); // Hareketsiz durumda Idle animasyonu
        }
        else if (Input.GetKey(KeyCode.LeftShift))
        {
            SetRun(); // Shift tuþuna basýlýyken ve hareket ederken Run animasyonu
        }
        else
        {
            SetWalk(); // Diðer durumlarda Walk animasyonu
        }

        // Zýplama mekaniði
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            SetJump();
        }

        // Yer çekimi etkisini uygula
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime); // Hýz vektörünü kullanarak karakteri hareket ettir
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