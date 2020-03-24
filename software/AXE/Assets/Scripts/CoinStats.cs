using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CoinStats : MonoBehaviour
{
    public int thorCoins;
    public int valkCoins;

    [SerializeField]
    private TextMeshProUGUI thorScore;
    [SerializeField]
    private TextMeshProUGUI valkScore;

    private void Awake()
    {
        thorCoins = 0;
        valkCoins = 0;
    }

    public int GetThorCoins()
    {
        return thorCoins;
    }

    public int GetValkCoins()
    {
        return valkCoins;
    }

    public void AddThorCoin(int coin)
    {
        thorCoins += coin;
        thorScore.SetText(thorCoins.ToString());
    }

    public void AddValkCoin(int coin)
    {
        valkCoins += coin;
        valkScore.SetText(valkCoins.ToString());
    }

    public void UseThorCoins(int numCoin)
    {
        thorCoins -= numCoin;
        thorScore.SetText(thorCoins.ToString());
    }

    public void UseValkCoins(int numCoin)
    {
        valkCoins -= numCoin;
        valkScore.SetText(valkCoins.ToString());
    }
}
