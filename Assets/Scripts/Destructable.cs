using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] private GameObject Cracked;

    public void DestroyCrate()
    {
        Instantiate(Cracked, transform.position, transform.rotation);
        Destroy(this.gameObject);
    }
}
