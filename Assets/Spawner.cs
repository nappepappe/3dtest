using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject cubePrefab;
    public GameObject ExplosionPrefab;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButton(0))
        {
            SpawnObject(cubePrefab, true);
        }

        if (Input.GetMouseButtonDown(1))
        {
            SpawnObject(ExplosionPrefab, false);
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject[] cubes = GameObject.FindGameObjectsWithTag("Respawn");
            for (int i = 0; i < cubes.Length; i++)
            {
                StartCoroutine(DeleteCube(cubes[i]));
            }
        }
    }

    private void SpawnObject(GameObject obj, bool aboveGround)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit info;
        if (Physics.Raycast(ray, out info))
        {
            Instantiate(obj, aboveGround ? info.point + Vector3.up : info.point, Quaternion.identity);
        }
    }

    private IEnumerator DeleteCube(GameObject obj)
    {
        yield return new WaitForSeconds(Random.Range(0.2f, 1.2f));
        Destroy(obj);
    }
}
