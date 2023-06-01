using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool isBoss;
    public int enemyUltaPoints;
    public int enemyDamage;
    [SerializeField] private float speed;

    [SerializeField] private Transform playerTransform;
    private Vector3 targetPosition;
    [SerializeField] private GameObject bulletPrefab;
    //private float bulletSpeed = 5f;

    private bool moveUp;
    
    private float shootingTimer = 0f;

    private void Start()
    {
        moveUp = true;
        SetUpEnemy(isBoss);

        playerTransform = GameObject.Find("Player").GetComponent<Transform>();
    }

    private void Update()
    {
        shootingTimer += Time.deltaTime;
        targetPosition = playerTransform.position;

        if (!isBoss)
        {
            if (this.transform.position.y < 5 && moveUp)
                this.transform.position += Vector3.up * Time.deltaTime;
            else
            {
                moveUp = false;
                this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
            }
        }
        else
        {
            if (shootingTimer >= 3f)
            {
                GameObject bullet = Instantiate(bulletPrefab, this.transform.position + new Vector3(2, 0, 0), this.transform.rotation) 
                    as GameObject;

                shootingTimer = 0f;
            }
            this.transform.position = Vector3.MoveTowards(this.transform.position, targetPosition, speed * Time.deltaTime);
        }

        if (GameManger.instance.killEnemies)
        {
            Destroy(this.gameObject);
        }
    }

    private void SetUpEnemy(bool isBoss)
    {
        if (isBoss)
        {
            this.enemyDamage = 25;
            this.enemyUltaPoints = 50;
            bulletPrefab.GetComponent<BulletManager>().bulletDamage = this.enemyDamage;
        }
        else
        {
            this.enemyDamage = 15;
            this.enemyUltaPoints = 15;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.gameObject.GetComponent<PlayerManager>().HealthDamage(this.enemyDamage);
            Destroy(this.gameObject);
        }
    }

    public void Damage(int damage)
    {
        this.enemyUltaPoints = this.enemyUltaPoints - damage <= 0 ? 0 : this.enemyUltaPoints -= damage;
        
        if (enemyUltaPoints == 0)
        {
            GameManger.instance.killedEnemies += 1;

            // doesn't see this.enemyUltaPoints ???
            GameManger.instance.ultaPoints += isBoss ? 25 : 15;
            Debug.Log("ultaPoints: " + GameManger.instance.ultaPoints + "\npoints per enemy: " + this.enemyUltaPoints);
            Destroy(gameObject);
        }
    }
}
