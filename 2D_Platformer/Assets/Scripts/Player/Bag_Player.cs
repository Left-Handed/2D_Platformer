using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Bag_Player : MonoBehaviour
{
    private int _countCoins;

    public event UnityAction<int> CoinCollected;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Coin coin))
        {
            _countCoins++;
            CoinCollected?.Invoke(_countCoins);
            Destroy(collision.gameObject);
        }
    }
}
