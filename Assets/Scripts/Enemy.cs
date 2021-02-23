using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Enemy : MonoBehaviour
{
    
    [SerializeField] GameObject enemyTakeDmgPrefab;
    [SerializeField] GameObject enemyDeath;
    [SerializeField] int points;
    [SerializeField] int health = 5;
    
    private int currentHealth;
     void OnEnable()
    {
        currentHealth = health;
    }

    void Update()
    {   
        var player = FindObjectOfType<Player>();
        
        
        if (player!=null) {
            GetComponent<NavMeshAgent>().SetDestination(player.transform.position);
        }
    }
    public void TakeDamage()
    {
        currentHealth--;
        if (currentHealth > 0)
        {
            Instantiate(enemyTakeDmgPrefab, transform.position, transform.rotation);
        }
        else
        {
            Instantiate(enemyDeath, transform.position, transform.rotation);
            gameObject.SetActive(false);
            Destroy(gameObject);
            UImanager.Add(points);
        }

      
    }

    private void OnCollisionEnter(Collision collision)
    {
        
       

        var player = collision.collider.GetComponent<Player>();
        if(player != null)
        {
            
            player.gameObject.SetActive(false);
        }
    }
}
