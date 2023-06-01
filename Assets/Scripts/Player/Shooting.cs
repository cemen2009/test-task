using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;

    private Camera _camera;
    private Vector3 point;
    private int size = 48;

    void Start()
    {
        _camera = GetComponent<Camera>();
        //point = new Vector3(_camera.pixelWidth / 2, _camera.pixelHeight / 2, 0);   // point = center of screen

        //Cursor.lockState = CursorLockMode.Locked;
        //Cursor.visible = true;
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, this.transform.position + Vector3.forward, this.transform.rotation);

        // bullet have power of player
        bullet.GetComponent<PlayerBullet>().bulletDamage = this.GetComponentInParent<PlayerManager>().power;
        bullet.GetComponent<PlayerBullet>().moveVector = transform.forward;
    }

    private void OnGUI()
    {
        if (GameManger.instance.showCursor)
        {
            float posX = _camera.pixelWidth / 2 - size / 4;
            float posY = _camera.pixelHeight / 2 - size / 2;
            GUI.contentColor = Color.green;
            GUI.Label(new Rect(posX, posY, size, size), "  |\n-- --\n  |\n");
        }
    }
}
