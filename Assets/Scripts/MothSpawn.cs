using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothSpawn : MonoBehaviour
{

    #region Variables
    private bool contains;
    private Vector3 spot;
    public GameObject Moth, DeathLight;
    [Range(1, 100)]public int numberOfMoths;
    #endregion

    void Start()
    {
        Vector3[] taken = new Vector3[numberOfMoths];
        for (int i = 0; i < numberOfMoths; i++)
        {
            contains = true;
            while (contains)
            {
                spot = new Vector3(Mathf.RoundToInt(Random.Range(-50f, 50f) * 10), 5, Mathf.RoundToInt(Random.Range(-50f, 50f) * 10));
                contains = false;
                for (int j = 0; j < taken.Length; j++)
                {
                    if (taken[j] == spot)
                    {
                        contains = true;
                        break;
                    }
                }
            }
            taken[i] = spot;
        }
        for (int i = 0; i < numberOfMoths; i++)
        {
            Instantiate(Moth, taken[i], Quaternion.identity);
        }
        StartCoroutine(RandomSpawning());
    }

    private IEnumerator RandomSpawning()
    {
        while (true)
        {
            yield return new WaitForSeconds(5f);
            Instantiate(DeathLight, new Vector3(Mathf.RoundToInt(Random.Range(-50f, 50f) * 10), 5, Mathf.RoundToInt(Random.Range(-50f, 50f) * 10)), Quaternion.identity);
            yield return new WaitForSeconds(5f);
            Instantiate(Moth, new Vector3(Mathf.RoundToInt(Random.Range(-50f, 50f) * 10), 5, Mathf.RoundToInt(Random.Range(-50f, 50f) * 10)), Quaternion.identity);
        }
    }

}
