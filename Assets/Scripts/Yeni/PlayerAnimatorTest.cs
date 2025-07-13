using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterRunState
{
    RunBack,
    WalkBack,
    Idle,
    Walk,
    Run
}

public class PlayerAnimatorTest : MonoBehaviour
{
    private int hiz =4;

    [Header("D�nme katsay�lar�")]
    public float donmeHizi = 45;
    public int rotateKatsayisi = 1;

    public float atlamaKuvveti = 5;
    public int yurumeHizi = 4;
    public int kosmaHizi = 7;

    private CharacterRunState zCharacterState;
    private CharacterRunState xCharacterState;

    Rigidbody rigidBody;
    Animator animator;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float zHareketi = Input.GetAxis("Vertical");
        float xHareketi = Input.GetAxis("Horizontal");

        //characterState = Input.GetKey(KeyCode.LeftShift) ?      CharacterRunState.Run : 
        //    CharacterRunState.Walk;

        if (zHareketi > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                zCharacterState = CharacterRunState.Run;
            }
            else
            {
                zCharacterState = CharacterRunState.Walk;
            }
        }
        else if (zHareketi < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                zCharacterState = CharacterRunState.RunBack;
            }
            else
            {
                zCharacterState = CharacterRunState.WalkBack;
            }
        }
        else
        {
            zCharacterState = CharacterRunState.Idle;
        }

        RunCharacterZ(zCharacterState);

        if (xHareketi > 0)
        {
            xCharacterState = CharacterRunState.Walk;
        }
        else if (xHareketi < 0)
        {
            xCharacterState = CharacterRunState.WalkBack;
        }
        else
        {
            xCharacterState = CharacterRunState.Idle;
        }

        RunCharacterX(xCharacterState);

        transform.Translate(xHareketi * hiz * Time.deltaTime, 0, zHareketi * hiz * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            JumpCharacter();
        }

        //rotateKatsayisi = Input.GetKey(KeyCode.Q) ? -1 : 1;
        //RotateCharacter();

        if (Input.GetKey(KeyCode.Q))
        {
            RotateCharacter(false);
        }
        else if (Input.GetKey(KeyCode.E))
        {
            RotateCharacter(true);
        }

    }

    public void RotateCharacter(bool sagadogru)
    {
        if (sagadogru)
        {
            transform.Rotate(Vector3.up * donmeHizi * Time.deltaTime);
        }
        else
        {
            transform.Rotate(-Vector3.up * donmeHizi * Time.deltaTime);
        }

    }

    public void RotateCharacter()
    {
        transform.Rotate(rotateKatsayisi * Vector3.up * donmeHizi * Time.deltaTime);
    }

    public void JumpCharacter()
    {
        rigidBody.AddForce(Vector3.up * atlamaKuvveti, ForceMode.Impulse);
    }

    public void RunCharacterZ(CharacterRunState state)
    {
        switch (state)
        {
            case CharacterRunState.Idle:
                hiz = 0;
                animator.SetFloat("ySpeed", 0);
                break;
            case CharacterRunState.Walk:
                hiz = yurumeHizi;
                animator.SetFloat("ySpeed", 1);
                break;
            case CharacterRunState.Run:
                hiz = kosmaHizi;
                animator.SetFloat("ySpeed", 2);
                break;
            case CharacterRunState.WalkBack:
                hiz = yurumeHizi;
                animator.SetFloat("ySpeed", -1);
                break;
                // OLMADI KONTROL ET
            case CharacterRunState.RunBack:
                hiz = kosmaHizi;
                animator.SetFloat("ySpeed", -2);
                break;
            default:
                break;
        }
    }

    public void RunCharacterX(CharacterRunState state)
    {
        switch (state)
        {
            case CharacterRunState.Idle:
                hiz = 0;
                animator.SetFloat("xSpeed", 0);
                break;
            case CharacterRunState.Walk:
                hiz = yurumeHizi;
                animator.SetFloat("xSpeed", 1);
                break;
            case CharacterRunState.WalkBack:
                hiz = yurumeHizi;
                animator.SetFloat("xSpeed", -1);
                break;
            default:
                break;
        }
    }
}
