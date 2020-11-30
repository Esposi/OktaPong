using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody rbd;
    public GameObject thisPlayer;
    public GameObject projectileObject;
    public GameObject positionProjectile;


    private float velocity;
    private float velocityRotation;
    private float verticalMovement;
    private float rotationMovement;

    public int playerNumber;


    void Start()
    {
        velocity = 5;
        velocityRotation = 2;

        rbd = thisPlayer.GetComponent<Rigidbody>();

    }

    void Update()
    {
        movementPlayer();
        shotProjectile();
    }

    //set player id

    public void setPlayerId(int numberToSet)
    {
        playerNumber = numberToSet;
    }

    //player movement
    void movementPlayer()
    {
        verticalMovement = Input.GetAxis("Vertical");
        rbd.velocity = new Vector3(rbd.velocity.x, rbd.velocity.y, verticalMovement * velocity);


        rotationMovement = Input.GetAxis("Horizontal") *velocityRotation;
        rotationMovement += Time.deltaTime;
        transform.Rotate(0, rotationMovement, 0);

    }

    //player shot
    void shotProjectile()
    {
        if (Input.GetKeyDown("space")) { 
            GameObject shot = Instantiate(projectileObject) as GameObject;
            shot.transform.position = positionProjectile.transform.position;
            shot.transform.rotation = transform.rotation;
            MechanicsManager.instance.endTurn();
        }
    }

    //identify projectile
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Projectile") {
            MechanicsManager.instance.dealDamage(playerNumber, collision.gameObject.GetComponent<ProjectileController>().damageToDeal);
            Destroy(collision.gameObject);
         }
    }


}
