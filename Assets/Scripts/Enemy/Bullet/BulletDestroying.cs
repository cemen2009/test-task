using UnityEngine;

public class BulletDestroying : MonoBehaviour
{
    private float lifeTime = 5f;
    private float bulletSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, lifeTime);
    }

    private void Update()
    {
        this.transform.position = Vector3.MoveTowards(this.transform.position, GameObject.Find("Player").transform.position, 
            bulletSpeed * Time.deltaTime);

        if (GameManger.instance.killEnemies)
        {
            Destroy(this.gameObject);
        }
    }
}
