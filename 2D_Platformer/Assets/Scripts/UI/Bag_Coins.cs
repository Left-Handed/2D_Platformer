using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Bag_Coins : MonoBehaviour
{
    [SerializeField] private TMP_Text _score; 
    [SerializeField] private Bag_Player _bag;

    private void OnEnable()
    {
        _bag.CoinCollected += OnCoinCollected;
    }

    private void OnDisable()
    {
        _bag.CoinCollected -= OnCoinCollected;
    }

    private void OnCoinCollected(int coinCont)
    {
        _score.text = coinCont.ToString();
    }
}
