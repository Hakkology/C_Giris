using System;
using UnityEngine;

public enum CharacterRunState
{
    RunBack,
    WalkBack,
    Idle,
    Walk,
    Run
}

public class PlayerMovementController : MonoBehaviour
{
    private int hiz =4;

    [Header("Dönme katsayýlarý")]
    public float donmeHizi = 45;
    public int rotateKatsayisi = 1;

    public float atlamaKuvveti = 5;
    public int yurumeHizi = 4;
    public int kosmaHizi = 7;

    public float maksEnerji = 100;
    private float mevcutEnerji;

    private CharacterRunState zCharacterState;
    private CharacterRunState xCharacterState;

    Rigidbody rigidBody;
    Animator animator;

    private bool kosuyorum;
    // Start is called before the first frame update

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigidBody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        mevcutEnerji = maksEnerji;
    }

    void Update()
    {
        kosuyorum = false;
        float zHareketi = Input.GetAxis("Vertical");
        float xHareketi = Input.GetAxis("Horizontal");

        //characterState = Input.GetKey(KeyCode.LeftShift) ?      CharacterRunState.Run : 
        //    CharacterRunState.Walk;

        if (zHareketi > 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && mevcutEnerji > 20)
            {
                zCharacterState = CharacterRunState.Run;
                kosuyorum = true;
            }
            else
            {
                zCharacterState = CharacterRunState.Walk;
            }
        }
        else if (zHareketi < 0)
        {
            if (Input.GetKey(KeyCode.LeftShift) && mevcutEnerji >20)
            {
                zCharacterState = CharacterRunState.RunBack;
                kosuyorum = true;
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

        EnerjiYonetimi();

    }

    private void EnerjiYonetimi()
    {
        if (kosuyorum)
        {
            mevcutEnerji -= 5 * Time.deltaTime;
        }
        else
        {
            if (mevcutEnerji < maksEnerji)
            {
                mevcutEnerji += 3 * Time.deltaTime;
            }
        }
        UIManager.Instance.hudManager.UpdateEnerjiMetin(mevcutEnerji);
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
