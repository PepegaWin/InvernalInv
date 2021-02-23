using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
   
    [SerializeField] Bullet bulletPreFab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float delay = 0.2f;
    [SerializeField] float bulletSpeed = 10f;
   
    Queue<Bullet> pool = new Queue<Bullet>();
    private Vector3 bulletDirection;
    float nextShootTime;
    
    
  
    void Update()
    {
        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out var raycastHit, Mathf.Infinity))
        {
            bulletDirection = (raycastHit.point - shootPoint.position).normalized;
            bulletDirection = new Vector3(bulletDirection.x, 0, bulletDirection.z);
            transform.forward = bulletDirection;
        }


        if (CanShoot())
        {
            Shoot();
        }
    }

    void Shoot()
    {
        nextShootTime = Time.time + delay;
        var bullet = GetBullet();
        bullet.transform.position = shootPoint.position;
        bullet.transform.rotation = shootPoint.rotation;
        bullet.GetComponent<Rigidbody>().velocity = bulletSpeed * bulletDirection;
    }

    bool CanShoot()
    {
        return Time.time >= nextShootTime;
    }

    Bullet GetBullet()
    {

        if (pool.Count > 0)
        {
            var bullet = pool.Dequeue();
            bullet.gameObject.SetActive(true);
            return bullet;
        }
        else
        {
            var bullet = Instantiate(bulletPreFab, shootPoint.position, shootPoint.rotation);
            bullet.SetGun(this);
            return bullet;
        }
    }

    public void AddToPool(Bullet bullet)
    {
        pool.Enqueue(bullet);
    }
}


