using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{

	public int maxHealth = 100;
	public HealthBar healthBar;



    // Start is called before the first frame update
    void Start()
    {
		healthBar.SetMaxHealth(maxHealth);
	}

	public void TakeDamage(int enemyDamage)
	{
		maxHealth -= enemyDamage;

		if(maxHealth <= 0)
		{
			Die();
		}
	}

	void Die()
    {
		Destroy(gameObject);
		FindObjectOfType<AudioManager>().Play("PlayerDeath");
	}

}
