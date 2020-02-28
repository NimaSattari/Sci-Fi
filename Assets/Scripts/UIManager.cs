using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private Text AmmoText;
    [SerializeField] private GameObject Coin;
    public void UpdateAmmo(int count)
    {
        AmmoText.text = count.ToString() + "/100";
    }
    public void CollectedCoin()
    {
        Coin.SetActive(true);
    }
    public void RemoveCoin()
    {
        Coin.SetActive(false);
    }
}
