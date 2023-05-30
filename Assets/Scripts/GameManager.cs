using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager instance
    {
        get
        {
            if(_instance == null)
            {
                _instance = FindObjectOfType<GameManager>();
            }
            return _instance;
        }
    }

    [SerializeField]
    private GameObject snowflake;   //���� ����

    void Start()
    {
        StartCoroutine(CreatesnowflakeRoutione());
    }
    void Update()
    {
        
    }

    IEnumerator CreatesnowflakeRoutione()   //1�ʸ��� snowflake ����
    {
        while(true) //���������� �����ǵ���
        {
            CreatSnowflake();
            yield return new WaitForSeconds(0.25f); //���ð�
        }
    }

    private void CreatSnowflake()
    {
        Vector3 pos = Camera.main.ViewportToWorldPoint(new Vector3(UnityEngine.Random.Range(0.0f, 1.0f), 1.1f, 0));
        pos.z = 0.0f;
        //ViewportToWorldPoint = ī�޶� �ȿ����� �����ǵ���
        Instantiate(snowflake, pos, Quaternion.identity);    //snowflake ������Ʈ ����
        //Quaternion.identity = ������Ʈ�� ȸ���� ����
    }
}
