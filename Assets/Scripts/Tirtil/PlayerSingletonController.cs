using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSingletonController : MonoBehaviour
{
    public static PlayerSingletonController singletonController;

    PlayerAnimatorController playerAnimatorController;
    PlayerHealthController playerHealthController;
    PlayerMovementController playerMovementController;
    PlayerGunController playerGunController;
    // Start is called before the first frame update
    void Awake()
    {
        playerAnimatorController = GetComponent<PlayerAnimatorController>();
        playerHealthController = GetComponent<PlayerHealthController>();
        playerMovementController = GetComponent<PlayerMovementController>();
        playerGunController = 
          GetComponent<PlayerGunController>();

        if (singletonController == null)
        {
            singletonController = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
