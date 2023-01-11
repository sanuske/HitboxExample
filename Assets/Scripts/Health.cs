using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events; // Needed for Unity Events

public class Health : MonoBehaviour
{
    [SerializeField] int health;
	[SerializeField] int maxHealth;
	public UnityEvent onDie; // Allows Drag/Drop linking of functions in the Inspector
    public void TakeDamage(int damage)
	{
		health -= damage;
		if(health <= 0)
		{
			onDie.Invoke(); // Invoking the event when something Dies. Let Player/Enemy say what happens when they die.
		}
	}

	public void ResetHealth()
	{
		health = maxHealth;
	}
}
