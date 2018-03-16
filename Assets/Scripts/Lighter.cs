using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour
{
    #region Variables
    public float lightStrength;
    #endregion

    private void Update()
    {
        lightStrength -= Time.deltaTime;
        if (lightStrength <= 0)
            Destroy(gameObject);
            
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            Destroy(other.gameObject);
    }
}
