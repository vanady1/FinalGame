using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _target;

    public int Reward;

    public GameObject Target => _target;

    private void Awake()
    {
        _target = GameObject.Find("Player");
    }

    public void Init(GameObject target)
    {
        _target = target;
    }
}
