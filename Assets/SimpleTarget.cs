using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleTarget : MonoBehaviour
{
    //Code obtained from https://www.youtube.com/watch?v=THnivyG0Mvo

    //How much health target has, and damageTaken looks at 
    public float targetHealth = 10f;
    public void damageTaken(float amount)
    
        //Looks at the health to see if it equals and/or is less than 0
    {
        targetHealth -= amount;
        if (targetHealth <= 0f)
        {
            TargetDestroy();
        }

        //When target health at 0, destroy target
        void TargetDestroy()
        {
            Destroy(gameObject);
        }
    }

}
