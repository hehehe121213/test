using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerPillar : MonoBehaviour
{
    [SerializeField]
    private GameObject PillarScore;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine (Spawner());
    }

    IEnumerator Spawner()
    {
        yield return new WaitForSeconds (2.5f);
        Vector3 temp = PillarScore.transform.position;
        temp.y = Random.Range(-1.8f, 1.9f);
        Instantiate(PillarScore, temp, Quaternion.identity);
        StartCoroutine(Spawner());

    }
}
