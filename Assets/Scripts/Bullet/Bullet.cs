using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Bullet : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _lifeTime;

    public int Damage => _damage;

    private void OnEnable()
    {
        StartCoroutine(DieOnLifeTimeEnd());
    }

    private void Update()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Wall wall))
        {
            Die();
        }
        else if (collision.gameObject.TryGetComponent(out EnemyHealth enemy))
        {
            if (enemy.isActiveAndEnabled)
            {
                enemy.TakeDamage(_damage);
                Die();
            }
        }
    }

    private IEnumerator DieOnLifeTimeEnd()
    {
        yield return new WaitForSeconds(_lifeTime);
        Die();
    }

    protected abstract void Die();

}
