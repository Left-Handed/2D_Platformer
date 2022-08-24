using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    [SerializeField] Transform _positionSpavn;
    [SerializeField] private Coin _coin;
    [SerializeField] private int _amount = 5;

    private List<Transform> _positionSpavns;

    private void Start()
    {
        SeparatePosition();
        DropCoin();
    }

    private void DropCoin()
    {
        int minNumberPosition = 0;

        for (int i = 0; i < _amount; i++)
        {
            int maxNumberPosition = _positionSpavns.Count;
            int numberPosition = Random.Range(minNumberPosition, maxNumberPosition);

            Transform target = _positionSpavns[numberPosition];
            Instantiate(_coin, target.position, Quaternion.identity);
            _positionSpavns.RemoveAt(numberPosition);
        }
    }

    private void SeparatePosition()
    {
        _positionSpavns = new List<Transform>();

        for (int i = 0; i < _positionSpavn.childCount; i++)
        {
            _positionSpavns.Add(_positionSpavn.GetChild(i));
        }
    }
}
