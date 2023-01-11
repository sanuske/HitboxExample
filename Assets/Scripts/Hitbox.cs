using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hitbox : MonoBehaviour
{
	[SerializeField] int damage = 1;
	private void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.TryGetComponent(out Hurtbox hurtbox)) // Check if the thing it hit is a Hurtbox, is always should be, but can't be too careful
		{
			if(hurtbox.owner.TryGetComponent(out Health target)) // Check if the thing has health. Maybe other non-health-y things can get hit later
			{
				target.TakeDamage(damage); // Smack it
			}
		}
	}
}
