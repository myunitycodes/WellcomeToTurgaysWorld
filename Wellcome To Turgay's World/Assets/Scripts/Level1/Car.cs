using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using PathCreation;
using UnityEditor.Rendering;
using PathCreation.Examples;

public class Car : MonoBehaviour
{
    public PathCreator pathCreator;
    public float speed;
     float currentSpeed;
    float distanceFromStart;// It is linked with time.

    [SerializeField] GameObject coin;
    List<GameObject> coinPool = new List<GameObject>();
    [SerializeField] float periyod;
    public float lifeTime;

    [SerializeField] GameObject player;

    PathFollower pathFollower;
    void Start()
    {

        currentSpeed = speed;
        for (int i = 0; i < 11; i++)
        {
            var newCoin = Instantiate(coin);
            newCoin.SetActive(false);
            coinPool.Add(newCoin);

        }

        InvokeRepeating("ActiveCoin", 5, periyod);
        pathFollower=GetComponent<PathFollower>();
        
    }

    private void FixedUpdate()
    {
       // MovementBezier(); //Path Follower kullandigim icin bunu kullnmiyorum ornek olsun diye burada.

      

    }

    void ActiveCoin()
    {
        var newCoin = GetCoin();
        if (newCoin != null)
        { 
           // newCoin.transform.position = transform.position + transform.TransformVector(new Vector3(0, 3f, -3));
            newCoin.transform.position = transform.position - transform.forward*0.2f;
            newCoin.SetActive(true);
            newCoin.GetComponent<Rigidbody>().AddForce((player.transform.position-transform.position).normalized*0.5f);
        }
    }
    GameObject GetCoin()
    {
        foreach (var item in coinPool)
        {
            if (!item.activeSelf)
            {
                return item;
            }
        }
        return null;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.tag=="Player")
        {
            currentSpeed = speed / 2;

        }
    }
    private void OnCollisionExit(Collision collision)
    {
        currentSpeed = speed;
    }


    void MovementBezier()//Kodlarla yapmak yerine Path Follever componenti ekleyerk yaptigim icin bu metodu kullanmiyorum.Ornek olmasi icin burada.
    {
        
            distanceFromStart += currentSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceFromStart);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceFromStart);
        
    }

    void FinishControl()
    {
        if (transform.position!=pathCreator.path.GetPoint(1))
        {
            distanceFromStart += currentSpeed * Time.deltaTime;
            transform.position = pathCreator.path.GetPointAtDistance(distanceFromStart);
            transform.rotation = pathCreator.path.GetRotationAtDistance(distanceFromStart);

        }
    }
}
