using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillWithTimer : MonoBehaviour
{
    public float cooldownTime = 5.0f; // Soðuma süresi 5 saniye
    private float skillTimer = 0f; // Beceri için kalan zaman

    void Start()
    {
        skillTimer = -1f; // Baþlangýçta beceri kullanýlabilir
    }

    void Update()
    {
        // Zamanlayýcýyý sürekli azalt
        skillTimer -= Time.deltaTime;

        // Eðer boþluk tuþuna basýlýrsa ve zamanlayýcý negatifse
        if (Input.GetKeyDown(KeyCode.Space) && skillTimer <= 0f)
        {
            UseSkill();
            // Zamanlayýcýyý resetle
            skillTimer = cooldownTime;
        }
    }

    void UseSkill()
    {
        Debug.Log("Beceri Kullanýldý: " + Time.time);
        // Beceri kullanýmýyla ilgili kodlar buraya eklenebilir
    }
}
