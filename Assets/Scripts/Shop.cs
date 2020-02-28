using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Player player = other.GetComponent<Player>();
                if (player != null)
                {
                    if (player.HasCoin == true)
                    {
                        player.HasCoin = false;
                        UIManager uIManager = GameObject.Find("Canvas").GetComponent<UIManager>();
                        if (uIManager != null)
                        {
                            uIManager.RemoveCoin();
                        }
                        AudioSource audio = GetComponent<AudioSource>();
                        audio.Play();
                        player.EnableWeapon();
                    }
                }
            }
        }
    }
}
