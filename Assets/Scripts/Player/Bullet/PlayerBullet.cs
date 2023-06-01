using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float lifeTime = 5f;
    private float speed = 1600f;
    [HideInInspector] public int bulletDamage;

    public Vector3 moveVector;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void FixedUpdate()
    {

        this.GetComponent<Rigidbody>().velocity = moveVector * Time.deltaTime * speed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            other.gameObject.GetComponent<Enemy>().Damage(this.bulletDamage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Damage(this.bulletDamage);
        }
    }
}
