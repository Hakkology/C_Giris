using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillWithTimer : MonoBehaviour
{
    public float cooldownTime = 5.0f; // So�uma s�resi 5 saniye
    private float skillTimer = 0f; // Beceri i�in kalan zaman

    void Start()
    {
        skillTimer = -1f; // Ba�lang��ta beceri kullan�labilir
    }

    void Update()
    {
        // Zamanlay�c�y� s�rekli azalt
        skillTimer -= Time.deltaTime;

        // E�er bo�luk tu�una bas�l�rsa ve zamanlay�c� negatifse
        if (Input.GetKeyDown(KeyCode.Space) && skillTimer <= 0f)
        {
            UseSkill();
            // Zamanlay�c�y� resetle
            skillTimer = cooldownTime;
        }
    }

    void UseSkill()
    {
        Debug.Log("Beceri Kullan�ld�: " + Time.time);
        // Beceri kullan�m�yla ilgili kodlar buraya eklenebilir
    }
}
