using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Gun _gun;

    public void SetGun(Gun gun) => _gun = gun;

    private void OnCollisionEnter(Collision collision)
    {
        gameObject.SetActive(false);
        _gun.AddToPool(this);
        var enemy = collision.collider.GetComponent<Enemy>();
        if(enemy != null)
        {
          enemy.TakeDamage();
        }

    }

    
}