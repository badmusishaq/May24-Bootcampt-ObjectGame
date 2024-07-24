using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

/// <summary>
/// The Player Class for controlling the player
/// </summary>
public class Player: PlayableObject
{
    private string nickName;
    [SerializeField] private float speed;
    [SerializeField] private Camera cam;

    [SerializeField] private float weaponDamage = 1;
    [SerializeField] private float bulletSpeed = 10;
    [SerializeField] private Bullet bulletPrefab;

    //public Action<float> OnHealthUpdate;

    private Rigidbody2D playerRB;

    private void Awake()
    {
        health = new Health(100, 0.5f, 50);
        playerRB = GetComponent<Rigidbody2D>();

        //Give the player the weapon
        weapon = new Weapon("Player Weapon", weaponDamage, bulletSpeed);

        //OnHealthUpdate?.Invoke(health.GetHealth());
    }

    /// <summary>
    /// Moving the player in a direction towards a target
    /// </summary>
    /// <param name="direction">the directio of movement</param>
    /// <param name="target">traget is the mouse movement</param>
    public override void Move(Vector2 direction, Vector2 target)
    {
        playerRB.velocity = direction * speed * Time.deltaTime; //Modifying the player velocity

        var playerScreenPos = cam.WorldToScreenPoint(transform.position);
        target.x -= playerScreenPos.x;
        target.y -= playerScreenPos.y;

        float angle = Mathf.Atan2(target.y, target.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, angle);
    }

    private void Update()
    {
        health.RegenHealth();
    }

    /// <summary>
    /// Responsible for making the player shoot
    /// </summary>
    public override void Shoot()
    {
        Debug.Log("Player is shooting");
        weapon.Shoot(bulletPrefab, this, "Enemy");
    }

    public override void Die()
    {
        Debug.Log("Player died!");
        Destroy(gameObject);
    }

    public override void Attack(float interval)
    {
        
    }

    public override void GetDamage(float damage)
    {
        Debug.Log("Player getting damaged! " + damage);
        health.DeductHealth(damage);

        //update health value from the C# Action
        //OnHealthUpdate?.Invoke(health.GetHealth());

        if (health.GetHealth() <= 0)
            Die();
    }

}
