using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBlasterRaycast : MonoBehaviour
{
    //Code obtained from https://www.youtube.com/watch?v=THnivyG0Mvo

    //Damage dealt per shot
    public float damage = 5f;
    //The distance the projectile could go before destroy itself
    public float rangeFalloff = 150f;
    //Apply to camera, so that the blaster could utilize it to aim and shoot
    public Camera playerCam;
    //The particle system on the blaster, and for impact
    public ParticleSystem blastFlash;
    public GameObject blastImpact;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }
    
    //The raycast takes the position of the camera, looks forward towards point,
    //and can fire the projectile to said target(assuming it's a target, it hits them)
    void Shoot()
    {
        blastFlash.Play();

        RaycastHit projectileHit;
        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out projectileHit, rangeFalloff))
        {
            //Console log making sure to notify that it work
            Debug.Log(projectileHit.transform.name);
            //Looks for target with the SimpleTarget script applied to them
            SimpleTarget target = projectileHit.transform.GetComponent<SimpleTarget>();
            //On target hit, add damage to the "amount" of damageTaken, so targetHealth ticks down
            if (target != null)
            {
                target.damageTaken(damage);
            }

            //Display the blast up on where it hits, and destroy after their use in 1.5s 
            GameObject impactDissipate = Instantiate(blastImpact,projectileHit.point,Quaternion.LookRotation(projectileHit.normal));
            Destroy(impactDissipate,1.5f);
        }

    }
}
