using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WaveCounter : MonoBehaviour
{
    [SerializeField] private EnemySpawner _spawner;
    [SerializeField] private TMP_Text _waveNumber;

    private void Awake()
    {
        OnNextWaveStarted();
    }

    private void OnEnable()
    {
        _spawner.NextWaveStarted += OnNextWaveStarted;
    }

    private void OnDisable()
    {
        _spawner.NextWaveStarted -= OnNextWaveStarted;
    }

    private void OnNextWaveStarted()
    {
        _waveNumber.text = (_spawner.CurrentWaveNumber + 1).ToString();
    }
}
