using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BagCoins : MonoBehaviour
{
    [SerializeField] private TMP_Text _score; 
    [SerializeField] private BagPlayer _bag;

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
