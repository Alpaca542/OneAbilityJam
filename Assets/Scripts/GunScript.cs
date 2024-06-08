using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GunScript : MonoBehaviour
{
    public GameObject[] blts;
    public GameObject activeBullet;
    public float firerate;
    public float damage;
    private bool Shooting;
    public bool Shotgun;
    void Update()
    {
        Vector3 diff = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        diff.Normalize();
        float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);

        if (Input.GetMouseButton(0) && !Shooting)
        {
            Shooting = true;
            CancelInvoke(nameof(ShootingInvoke));
            InvokeRepeating(nameof(ShootingInvoke), 0f, firerate);
        }
        if (Input.GetMouseButtonUp(0))
        {
            Shooting = false;
            CancelInvoke(nameof(ShootingInvoke));
        }
    }
    public void ShootingInvoke()
    {
        GameObject bullet = Instantiate(activeBullet, transform.position, transform.rotation);
        if (Shotgun)
        {
            foreach(Transform child in bullet.transform)
            {
                child.GetComponent<BulletScript>().FromPlayer = true;
                child.GetComponent<BulletScript>().Damage = damage;
                child.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 1000f);
            }
        }
        else
        {
            bullet.GetComponent<BulletScript>().FromPlayer = true;
            bullet.GetComponent<BulletScript>().Damage = damage;
            bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * 1000f);
        }
    }
}
