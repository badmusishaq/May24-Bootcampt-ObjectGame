using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public static int score = 0;
    int gameLevel;
    // Start is called before the first frame update
    void Start()
    {
        gameLevel = 1;

        //Create a player
        Player player = new Player();

        //Create two enemies
        Enemy enemy1 = new Enemy();
        Enemy enemy2 = new Enemy();

        //Create 3 weapons
        Weapon weapon1 = new Weapon();
        //Weapon weapon2 = new Weapon("Rifle", 30);
        //Weapon weapon4 = new Weapon("Machine Gun", 50);
        Weapon weapon3 = new Weapon();


        //Enums
        EnemyType enemyType1 = new EnemyType();
        enemyType1 = EnemyType.Melee;

        EnemyType enemyType2 = new EnemyType();
        enemyType2 = EnemyType.MachineGun;

        Health enemyHealth = new Health(100, 5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
