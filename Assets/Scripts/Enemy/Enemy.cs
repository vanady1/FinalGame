using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameObject _target;

    public GameObject Target => _target;

    private void Awake()
    {
        _target = FindObjectOfType<PlayerHealth>().gameObject;
    }
}
