using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cnn : MonoBehaviour {
    //申请GameObject变量用来承载预制体（拖动预制体赋值）
    /*
    public GameObject bullet;
    public Transform fireposition;

    //申请float变量设置推动力大小
    public float thrust = 100;
    Vector3 s = new Vector3(1,0,0);

    //检测开火函数
    void CheckShoot()
    {

        //是否输入了“Fire1”（默认鼠标左键和左Ctrl键）
        if (Input.GetButtonDown("Fire1"))
        {

            
            //实例化一个bullet的克隆体。
            //GameObject clone = Instantiate(bullet,fireposition.position,fireposition.rotation)as GameObject;

            //获取克隆体的刚体组件。

            //给克隆体的刚体组件一个推动力。
            //rb.AddForce(new Vector3(100,0,0));
            GameObject go = Instantiate(bullet, fireposition.position, fireposition.rotation) as GameObject;
            Rigidbody rb = go.GetComponent<Rigidbody>();
            rb.velocity = s * thrust;
        }
    }



    void Update()
    {
        CheckShoot();
    }
    */








    private Transform firePosition;
    public GameObject bulletPrefab;
    public KeyCode fireKey = KeyCode.Space;
    public float bulletSpeed = 10;//速度?????????????????????
    int count = 0;//累计次数
    int flag = 0;//状态判断
    int getRangeNum = 0;//随机数
    float time = 0;

    bool iskeydown = false;
    bool iskey = false;
    // Use this for initialization
    void Start()
    {
        firePosition = transform.Find("FirePosition");
    }


    //判断按键状态
    //bool KeyState()
    //{

    //}

    //长按fire
    void Fire1()
    {
        if (Input.GetKeyDown(fireKey) || iskey)
        {
            iskeydown = true;
            int rangeRadomNum = 0;
            rangeRadomNum = Random.Range(-100, 100);//控制扇形范
            getRangeNum = rangeRadomNum;
            bool a = true;
            count++;
            if (count % 3 == 0)
                a = false;
            else
                a = true;
            Debug.Log("第" + count.ToString() + "得到的随机数：" + count % 3);
            if (!a)
            {
                firePosition.localRotation *= Quaternion.Euler(0, 0 * Time.deltaTime, 0);
            }
            else
            {
                firePosition.localRotation *= Quaternion.Euler(0, -rangeRadomNum * Time.deltaTime, 0);//
                flag = 1;
            }
            if (!iskey)
                NewBullet();
        }
        if (flag == 1)
        {
            firePosition.localRotation *= Quaternion.Euler(0, getRangeNum * Time.deltaTime, 0);
        }
        flag = 0;
        //firePosition.localRotation *= Quaternion.Euler(0, -1000 * Time.deltaTime, 0);//先改变下一帧才运动
    }

    //单按fire
    void Fire2()
    {
        if (Input.GetKey(fireKey) || iskey)
        {
            iskeydown = true;
            int rangeRadomNum = 0;
            rangeRadomNum = Random.Range(-1000, 1000);//控制扇形范
            getRangeNum = rangeRadomNum;
            bool a = true;
            count++;
            if (count % 3 == 0)
                a = false;
            else
                a = true;
            Debug.Log("第" + count.ToString() + "得到的随机数：" + count % 3);
            if (!a)
            {
                firePosition.localRotation *= Quaternion.Euler(0, 0 * Time.deltaTime, 0);
            }
            else
            {
                firePosition.localRotation *= Quaternion.Euler(0, -rangeRadomNum * Time.deltaTime, 0);//
                flag = 1;
            }
            NewBullet();
        }
        if (flag == 1)
        {
            firePosition.localRotation *= Quaternion.Euler(0, getRangeNum * Time.deltaTime, 0);
        }
        flag = 0;
        //firePosition.localRotation *= Quaternion.Euler(0, -1000 * Time.deltaTime, 0);//先改变下一帧才运动
    }

    void NewBullet()
    {
        GameObject go = Instantiate(bulletPrefab, firePosition.position, firePosition.rotation) as GameObject;
        go.GetComponent<Rigidbody>().velocity = go.transform.forward * bulletSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        if (iskeydown)
            time += Time.deltaTime;
        if (time > 0.05)
        {
            time = 0;
            Fire2();
            iskey = true;
        }
        if (Input.GetKeyUp(fireKey))
        {
            iskeydown = false;
            iskey = false;
        }
        Fire1();
    }
    
}


    

