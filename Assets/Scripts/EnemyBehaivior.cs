using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaivior : MonoBehaviour
{
    public Transform Player;
    [Range(1f,10f)]
    [SerializeField] float EnemySpeed;
    [SerializeField] float distanceCheck;
    [SerializeField] GameObject bullet;
    [SerializeField] GameObject bulletspawnpoint;
    private bool ishooot = true;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(Player);
        if(Vector3.Distance(transform.position, Player.position)< distanceCheck)
        {
            //transform.position += transform.forward * EnemySpeed * 3 * Time.deltaTime;
            if(ishooot)
            {

                StartCoroutine(shoot());
            }
        }
    }

    IEnumerator shoot()
    {
        ishooot = false;
       GameObject bulletInst = Instantiate(bullet, bulletspawnpoint.transform.position, Quaternion.identity);
        //bulletInst.transform.position += transform.forward * EnemySpeed * 3 * Time.deltaTime;
        yield return new WaitForSeconds(2);
        ishooot = true;

    }
}
