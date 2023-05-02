using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemySpawner : ObjectPool
{
    [SerializeField] private float _spawnZoneSize;
    [SerializeField] private GameObject _enemyTemplate;
    [SerializeField] private GameObject _target;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private List<Wave> _waves;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;
    private int _died;

    public event UnityAction AllEnemyDied;
    public event UnityAction NextWaveStarted;

    public int CurrentWaveNumber => _currentWaveNumber;

    public void NextWave()
    {
        if (_currentWaveNumber > _waves.Count - 2)
        {
            SetWave(_currentWaveNumber);

        }
        else
        {
            SetWave(++_currentWaveNumber);
        }

        _spawned = 0;
        _died = 0;
        NextWaveStarted?.Invoke();
    }

    private void Start()
    {
        Initialize(_enemyTemplate);
        SetWave(_currentWaveNumber);
    }

    private Vector3 GetRandomSpawnPosition()
    {
        return new Vector3(Random.Range(-_spawnZoneSize / 2, _spawnZoneSize / 2 + 1), Random.Range(-_spawnZoneSize / 2, _spawnZoneSize / 2 + 1), 0);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            TrySetupEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            _currentWave = null;
        }
    }

    private void TrySetupEnemy()
    {
        if (TryGetObject(out GameObject enemy))
        {
            enemy.GetComponent<EnemyHealth>().ResetHealth();
            enemy.GetComponent<EnemyHealth>().Died += OnEnemyDied;
            enemy.transform.position = GetRandomSpawnPosition();
            enemy.transform.rotation = Quaternion.identity;
            enemy.SetActive(true);
        }
        else
        {
            Debug.Log("Failed to Get Enemy");
        }
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDied(Enemy enemy, int reward)
    {
        if (++_died == _spawned)
        {
            AllEnemyDied?.Invoke();
        }

        _target.GetComponent<PlayerMoney>().AddMoney(reward);
        enemy.GetComponent<EnemyHealth>().Died -= OnEnemyDied;
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = new Color(1, 0, 0, .5f);
        Gizmos.DrawCube(transform.position, new Vector3(_spawnZoneSize, _spawnZoneSize, 0));
    }
}

[System.Serializable]
public class Wave
{
    public float Delay;
    public int Count;
}
