using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
  
    public AudioClip audioSource;
    // Start is called before the first frame update
    void Start()
    {
       
    }
    public GameObject BulletPrefab;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(BulletPrefab, transform.position, Quaternion.identity);
            GetComponent<AudioSource>().PlayOneShot(audioSource);
        }
    }
}
