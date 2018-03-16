using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSpawn : MonoBehaviour
{
    #region Variables
    public GameObject light, strongLight;
    private bool isRunning = false;
    private Ray ray;
    #endregion

    void Update()
    {
        if (Input.GetMouseButton(0))
            Instantiate(light, new Vector3(Spawn().x, 5, Spawn().z), Quaternion.identity);
        else if (Input.GetMouseButton(1) && isRunning == false)
            StartCoroutine(StrongLight());
    }

    private IEnumerator StrongLight()
    {
        isRunning = true;
        Instantiate(strongLight, new Vector3(Spawn().x, 5, Spawn().z), Quaternion.identity);
        yield return new WaitForSeconds(0.5f);
        isRunning = false;
    }

    private Vector3 Spawn()
    {
        RaycastHit hit;
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        Physics.Raycast(ray, out hit);
        return hit.point;
    }
}