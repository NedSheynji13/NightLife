using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountUp : MonoBehaviour {

	#region Variables
    public static int MothCount = 0;
    public Text Score;
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        MothCount++;
        Destroy(other.gameObject);
        Score.text = "You saved " + MothCount + " Moths so far!";
    }
}
