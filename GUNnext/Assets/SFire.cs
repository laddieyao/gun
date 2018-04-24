using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFire : MonoBehaviour {

    public Transform fireposition;
    public Transform fireposition1;
    public Transform fireposition2;
    public Transform fireposition3;
    public Transform fireposition4;
    //public GameObject[] bulletPrefab = new GameObject[5];
    public GameObject bulletPrefab;
    public float Speed = 10;
    public KeyCode firekey = KeyCode.Space;
    // Use this for initialization
    void Start()
    {
        fireposition = transform.Find("FirePosition");
        fireposition1 = transform.Find("FirePosition1");
        fireposition2 = transform.Find("FirePosition2");
        fireposition3 = transform.Find("FirePosition3");
        fireposition4 = transform.Find("FirePosition4");
        //bulletPrefab=new GameObject[4];
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(10, 0, 5);
        if (Input.GetKeyDown(firekey))
        {
            int i = 0;
            for (i = 0; i < 5; i++)
            {
                if (i == 0)
                {
                    fireposition.localRotation *= Quaternion.Euler(0, -45, 0);
                    GameObject go1 = Instantiate(bulletPrefab, fireposition.position, fireposition.rotation) as GameObject;
                    go1.GetComponent<Rigidbody>().velocity = go1.transform.forward * Speed;
                    fireposition.localRotation *= Quaternion.Euler(0, 45, 0);
                }
                if (i == 1)
                {
                    fireposition1.localRotation *= Quaternion.Euler(0, -22, 0);
                    GameObject go = Instantiate(bulletPrefab, fireposition1.position, fireposition1.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * Speed;
                    fireposition1.localRotation *= Quaternion.Euler(0, 22, 0);
                }
                if (i == 2)
                {
                    fireposition2.localRotation *= Quaternion.Euler(0, 0, 0);
                    GameObject go = Instantiate(bulletPrefab, fireposition2.position, fireposition2.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * Speed;
                    fireposition2.localRotation *= Quaternion.Euler(0, 0, 0);
                }
                if (i == 3)
                {
                    fireposition3.localRotation *= Quaternion.Euler(0, 22, 0);
                    GameObject go = Instantiate(bulletPrefab, fireposition3.position, fireposition3.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * Speed;
                    fireposition3.localRotation *= Quaternion.Euler(0, -22, 0);
                }
                if (i == 4)
                {
                    fireposition4.localRotation *= Quaternion.Euler(0, 45, 0);
                    GameObject go = Instantiate(bulletPrefab, fireposition4.position, fireposition4.rotation) as GameObject;
                    go.GetComponent<Rigidbody>().velocity = go.transform.forward * Speed;
                    fireposition4.localRotation *= Quaternion.Euler(0, -45, 0);
                }
            }
            //Vector3 rotationVector3 = new Vector3(10f, 90f, 5f);
            //Quaternion rotation = Quaternion.Euler(rotationVector3);
            //fireposition.rotation = rotation;


        }
        //void fire()
        //{
        //    GameObject go = Instantiate(bulletPrefab[i], fireposition.position, fireposition.rotation) as GameObject;
        //    go.GetComponent<Rigidbody>().velocity = go.transform.forward * Speed;
        //}
    }
}
