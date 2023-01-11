using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] Health healthComponent;
    [SerializeField] SpriteRenderer rend;
    [SerializeField] TrailRenderer trail; // I added a trail because trails look nice.
    [SerializeField] Rigidbody2D rb;
    [SerializeField] InputManager inputs;

    [SerializeField] Hitbox dashHitbox;
    [SerializeField] Hurtbox hurtbox;

    [Header("Stats")]
    [SerializeField] float speed = 5;
    [SerializeField] float jumpSpeed = 10;
    [SerializeField] float dashSpeed = 10;
    [SerializeField] float dashDuration = 2;
    float dashTimer;
 
    int lookDirection = 1;

    [Header("Misc")]
    [SerializeField] int dashDireciton = 1;
    [SerializeField] Vector2 spawnPoint;
    [SerializeField] Vector2 tempVelocity;

	private void Start()
	{
        spawnPoint = transform.position; // Cache the Spawn point for later
	}
	// Update is called once per frame
	void Update()
    {
        tempVelocity.y = rb.velocity.y;

        tempVelocity.x = inputs.moveDirection * speed;
        if (tempVelocity.x > 0)
        {
            lookDirection = 1;
            rend.flipX = true;
        }
        else if (tempVelocity.x < 0)
        {
            lookDirection = -1;
            rend.flipX = false;

        }


        if (inputs.DashPressed && dashTimer <= 0)
		{
			StartDash();

		}
		if (dashTimer > 0)
		{
            dashTimer -= Time.deltaTime;
            tempVelocity.x = lookDirection * dashSpeed;
            if (dashTimer <=0)
			{
				EndDash();
			}
		}

        if(inputs.jumpPressed)
		{
            tempVelocity.y = jumpSpeed;
		}

        rb.velocity = tempVelocity;
    }

	private void EndDash()
	{
		trail.emitting = false;
        dashHitbox.gameObject.SetActive(false); // Disabling the whole gameObject of the Hitbox to prevent OnTrigger/OnCollision calls
        hurtbox.gameObject.SetActive(true);
	}

	private void StartDash()
	{
        hurtbox.gameObject.SetActive(false);
        dashHitbox.gameObject.SetActive(true);

        dashTimer = dashDuration;
		trail.emitting = true;
	}

	public void Die() // Called by a Unity Event in the Health Component
	{
        transform.position = spawnPoint;
        healthComponent.ResetHealth();
	}
}
