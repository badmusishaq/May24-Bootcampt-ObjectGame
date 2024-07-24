using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    [Header("Game Attributes")]
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private Transform[] spawnPositions;
    [SerializeField] private float enemySpawnRate;

    private GameObject tempEnemy;

    private bool isEnemySpawning;

    private Weapon meleeWeapon = new Weapon("Melee", 1, 0);

    public ScoreManager scoreManager;

    private static GameManager instance;

    public static GameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }

        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        isEnemySpawning = true;
        StartCoroutine(EnemySpawner());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.M))
        {
            CreateEnemy();
        }
    }

    void CreateEnemy()
    {
        tempEnemy = Instantiate(enemyPrefab);
        int index = Random.Range(0, spawnPositions.Length);
        tempEnemy.transform.position = spawnPositions[index].position;
        tempEnemy.GetComponent<Enemy>().weapon = meleeWeapon;
        tempEnemy.GetComponent<MeleeEnemy>().SetMeleeEnemy(2, 0.25f);
    }

    IEnumerator EnemySpawner()
    {
        while(isEnemySpawning)
        {
            yield return new WaitForSeconds(1 / enemySpawnRate);
            CreateEnemy();
        }
    }

    public void SetEnemySpawnStatus(bool enemystatus)
    {
        isEnemySpawning = enemystatus;
    }
}
