using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public float speed;
    public int damageToDeal;

    void Start()
    {
    }

    void Update()
    {
        movementProjectile();

    }

    // projectile movement
    private void movementProjectile()
    {
        transform.position += transform.forward * Time.deltaTime * speed;
    }

    //projectile collisions
    private void OnTriggerEnter(Collider collision)
    {
        getNewDirection(collision.tag);
        

    }

    private void getNewDirection(string tagToCheck)
    {
        if (tagToCheck == "VertBar") speed *= -1;
        transform.Rotate(0, 2 * (90 - (transform.localEulerAngles.y)), 0);

    }


}
