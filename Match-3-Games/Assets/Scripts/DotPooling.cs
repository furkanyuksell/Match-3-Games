using System.Collections;
using System.Collections.Generic;
using UnityEngine.Pool;
using UnityEngine;

public class DotPooling : MonoBehaviour
{
    ObjectPool<Dot> _dotPool;
    [SerializeField]Dot[] _dotPrefab;
    void Awake()
    {
        _dotPool = new ObjectPool<Dot>(CreateDot, OnTakeFromPool, OnReturnToPool);
    }

    public Dot GetDot()
    {
        return _dotPool.Get();
    }

    Dot CreateDot()
    {
        int dotToUse = Random.Range(0, _dotPrefab.Length);
        var dot = Instantiate(_dotPrefab[dotToUse]);
        dot.SetPool(_dotPool);
        return dot;
    }

    void OnTakeFromPool(Dot dot)
    {
        dot.gameObject.SetActive(true);
    }

    void OnReturnToPool(Dot dot)
    {
        dot.gameObject.SetActive(false);
    }
}
