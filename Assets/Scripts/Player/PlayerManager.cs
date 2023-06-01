using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public int health;
    public int power;
    public static bool isGrounded;

    private void Start()
    {
        health = 100;
        power = 50;
    }

    private void Update()
    {
        if (this.transform.position.y <= 0.9f)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            HealthDamage(other.gameObject.GetComponent<Enemy>().enemyDamage);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Bullet"))
        {
            HealthDamage(other.gameObject.GetComponent<BulletManager>().bulletDamage);
            Destroy(other.gameObject);
        }
    }

    public void HealthDamage(int damage)
    {
        if (this.health - damage <= 0)
        {
            this.health = 0;
            // TODO: call gameManager Death()
            GameManger.instance.PlayerDeath();
        }
        else
        {
            this.health -= damage;
            // TODO: call gameManager HealthDamage()
        }

        Debug.Log("Player get damage " + damage);
    }
}
