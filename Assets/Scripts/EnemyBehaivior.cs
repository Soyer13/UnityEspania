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
    [SerializeField] GameObject[] wanderingPoints;
    private bool ishooot = true;
    private bool isWandering = true;
    // Start is called before the first frame update
    void Start()
    {
        //Player = GameObject.FindGameObjectWithTag("Player").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Vector3.Distance(transform.position, Player.position)< distanceCheck)
        {
            transform.LookAt(Player);
            //transform.position += transform.forward * EnemySpeed * 3 * Time.deltaTime;
            if(ishooot)
            {

                StartCoroutine(shoot());
            }
        }
        else if(isWandering)
        {
            enemyWander();
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

    IEnumerator enemyWander() {
        isWandering = false;
        int movePoint = Random.Range(0, wanderingPoints.Length);
        if(this.transform.position != wanderingPoints[movePoint].transform.position)
        {
            Debug.Log("Move to " + movePoint);
            transform.LookAt(wanderingPoints[movePoint].transform.position);
            transform.position += transform.forward * EnemySpeed * Time.deltaTime;
        }
        else
        {
            isWandering = true;
        }
        yield return new WaitForSeconds(50);
        isWandering = true;
    }
}
