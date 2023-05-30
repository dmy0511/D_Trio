using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Snowball_1 : MonoBehaviour
{
    Rigidbody2D rigidbody;
    public float snowballSpeed;

    Transform People_1_pos;
    Vector2 dir;

    public int Attack;  //Soldiers_1�� ���ݷ�

    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        rigidbody.velocity = transform.position * snowballSpeed;

        People_1_pos = GameObject.Find("People_1").GetComponent<Transform>();
        dir = People_1_pos.position - transform.position;
        GetComponent<Rigidbody2D>().AddForce(dir.normalized * Time.deltaTime * 100000);
    }

    void FixedUpdate()
    {
        float angle = Mathf.Atan2(rigidbody.velocity.y, rigidbody.velocity.x) * Mathf.Rad2Deg;
        transform.eulerAngles = new Vector3(0, 0, angle);
    }

    private void OnTriggerEnter2D(Collider2D collision) //���_1�� �浹�� ����
    {
        if (collision.gameObject.tag == "People_1")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnBecameInvisible()    //ȭ�� ������ ������ �ı�
    {
        Destroy(gameObject);
    }
}
