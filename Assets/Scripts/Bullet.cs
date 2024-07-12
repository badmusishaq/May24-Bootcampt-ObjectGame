using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private float damage;
    [SerializeField] private float speed;

    private void Update()
    {
        Move();
    }

    void Move()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    void Damage(IDamageable damageable)
    {
        damageable.GetDamage(damage);
        Debug.Log($"Damaged something");
        LevelLoader.score++;
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other.gameObject.name);

        IDamageable damageable = other.GetComponent<IDamageable>();
        Damage(damageable);
    }
}
