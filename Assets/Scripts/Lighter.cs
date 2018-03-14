using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lighter : MonoBehaviour {

    #region Variables
    public GameObject Light;
    private bool isRunning = false;
    private Ray ray;
    #endregion

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isRunning == false)
        {
            isRunning = true;
            StartCoroutine(SpawnLight());
        }
    }

    private IEnumerator SpawnLight()
    {
        GameObject Lighter = Instantiate(Light, Spawn(), Quaternion.identity) as GameObject;
        yield return new WaitForSeconds(0.1f);
        isRunning = false;
        yield return new WaitForSeconds(5f);
        Destroy(Lighter);
    }

    private Vector3 Spawn()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
            return hit.point;
        else
            return Vector3.up * 5;
    }
}
