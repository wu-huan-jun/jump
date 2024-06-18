using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Player playerControll;
    [SerializeField] bool reached;//����Ƿ��Ѿ������ƽ̨��
    public int floorIndex;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
        playerControll = player.GetComponent<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!reached)
        {
            if (player.transform.position.y > transform.position.y//��ҵ����˱�ƽ̨�ߵ�λ��
                && playerControll.TestGround())//����Ѿ�վס
            {
                reached = true;
                Debug.Log("�ڵ�" + (floorIndex+1).ToString() + "�������˸����");
            }
        }
        else
        {
            if (player.transform.position.y < transform.position.y)//��ҵ����˱�ƽ̨�͵�λ��
                player.transform.position = new Vector3(transform.position.x,transform.position.y+0.2f,0);
        }
    }
}
