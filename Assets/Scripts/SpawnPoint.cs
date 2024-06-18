using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] Player playerControll;
    [SerializeField] bool reached;//玩家是否已经到这个平台上
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
            if (player.transform.position.y > transform.position.y//玩家到达了比平台高的位置
                && playerControll.TestGround())//玩家已经站住
            {
                reached = true;
                Debug.Log("在第" + (floorIndex+1).ToString() + "层设置了复活点");
            }
        }
        else
        {
            if (player.transform.position.y < transform.position.y)//玩家掉到了比平台低的位置
                player.transform.position = new Vector3(transform.position.x,transform.position.y+0.2f,0);
        }
    }
}
