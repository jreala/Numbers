using UnityEngine;
using System.Collections;

public class FallingStar : MonoBehaviour {

    public GameObject[] Stars;

	void OnTriggerEnter2D(Collider2D col)
    {
        col.transform.position = new Vector3(Random.Range(-2.5f, 2.5f), col.transform.position.y + 20, col.transform.position.z);
    }
}
