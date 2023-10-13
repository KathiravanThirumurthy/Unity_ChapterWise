using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> _gObj;
    [SerializeField]
    private bool isGameActive;
    // Start is called before the first frame update
    void Start()
    {
        
        StartCoroutine(SpawnObjects());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator SpawnObjects()
    {
        while(true)
        {

            yield return new WaitForSeconds(2f);
            int index = Random.Range(0, _gObj.Count);
            Instantiate(_gObj[index],RandomPosition(),Quaternion.identity);
        }
        
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }
    
}
