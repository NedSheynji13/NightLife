using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothBehaviour : MonoBehaviour
{
    #region Variables
    public float attraction = 0;    //The amount of interest for the shiniest light
    private GameObject interest;    //The shiniest light in terms of lightstrength
    #endregion

    private void FixedUpdate()
    {
        Collider[] cols = Physics.OverlapSphere(transform.position, 50);
        for (int i = 0; i < cols.Length; i++)
        {
            if (cols[i].gameObject.tag == "Light")
            {
                if (cols[i].gameObject.GetComponent<Lighter>().lightStrength > attraction)
                    interest = cols[i].gameObject;

            }
        }
        if (interest != null)
            Move(interest);
    }
    private void Move(GameObject col)
    {
        attraction = col.GetComponent<Lighter>().lightStrength;
        transform.position = Vector3.MoveTowards(transform.position, col.transform.position, 10 * Time.deltaTime);
        Vector3 dir = col.transform.position - transform.position;
        if (dir.magnitude != 0)
        {
            Quaternion toRotation = Quaternion.LookRotation(dir);
            transform.rotation = Quaternion.Slerp(transform.rotation, toRotation, 10 * Time.deltaTime);
        }
    }
}
