using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrateTimer : MonoBehaviour
{
    public int delay = 0;

    void Start()
    {
        StartCoroutine(SelfDestruct());
    }
    IEnumerator SelfDestruct()
    {
        yield return new WaitForSeconds(2f + delay);
        Destroy(gameObject);
    }
}
