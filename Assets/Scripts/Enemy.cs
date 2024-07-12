using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : PlayableObject
{
    [SerializeField] protected float speed;
    protected Transform target;

    private EnemyType enemyType;


    protected virtual void Start()
    {
        target = GameObject.FindWithTag("Player").transform;
    }

    protected virtual void Update()
    {
        if(target != null)
        {
            Move(target.position);
        }
        else
        {
            Move(speed);
        }
    }

    public override void Move(Vector2 direction, Vector2 target)
    {
        Debug.Log($"Moving toward the taget");
    }

    public override void Move(Vector2 direction)
    {
        direction.x -= transform.position.x;
        direction.y -= transform.position.y;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Move(float speed)
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
    }

    public override void Shoot()
    {
        Debug.Log("Enemy shooting");
    }

    public override void Attack(float interval)
    {
        Debug.Log($"Enemy attacking at {interval}");
    }

    public override void Die()
    {
        Debug.Log($"Enemy died");
    }

    public void SetEnemyType(EnemyType enemyType)
    {
        this.enemyType = enemyType;
    }

    public override void GetDamage(float damage)
    {

    }
}
