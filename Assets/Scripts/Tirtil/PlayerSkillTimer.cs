using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkillTimer : MonoBehaviour
{
    public float cooldownSure = 5.0f;

    private float sonrakiKullanimSure = 0;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q) && Time.time >= sonrakiKullanimSure)
        {
            SkillAt();
            sonrakiKullanimSure = Time.time + cooldownSure;
        }
    }

    private void SkillAt()
    {
        //throw new NotImplementedException();
    }
}
