using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
  
    private int minForce=12;
    private int maxForce=16;
    private int minTorque = -10;
    private int maxTorque = 10;
    private Rigidbody rgd;
    [SerializeField]
    private int m_thrust;
   
    private ScoreText _scoreText;
    private int points = 5;
    private SpawnManager _spawnManager;
    // Start is called before the first frame update
    void Start()
    {
            rgd = GetComponent<Rigidbody>();
            m_thrust = Random.Range(12, 16);
            rgd.AddForce(RandomForce(), ForceMode.Impulse);
            rgd.AddTorque(RandomTorque(), ForceMode.Impulse);
            // transform.position=RandomPosition();
            _scoreText = FindObjectOfType<ScoreText>();
        _spawnManager = GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
       
    }
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minForce, maxForce);
    }
    Vector3 RandomTorque()
    {
        return new Vector3(Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque), Random.Range(minTorque, maxTorque));
    }
    Vector3 RandomPosition()
    {
        return new Vector3(Random.Range(-4, 4), -6);
    }

   /* 
   */
    private void OnTriggerEnter(Collider other)
    {
              
            Destroy(this.gameObject);
        
     }
    
}
