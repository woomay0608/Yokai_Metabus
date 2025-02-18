using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BgLooper : MonoBehaviour
{

    public int ObstacleCount = 0;
    public Vector3 ObstacleLastPosition = Vector3.zero;

    public int BackGroundCount = 5;
    // Start is called before the first frame update
    void Start()
    {
        Obstacle[] obstacles = GameObject.FindObjectsOfType<Obstacle>();
        ObstacleLastPosition = obstacles[0].transform.position;
        ObstacleCount = obstacles.Length;
        for (int i = 0; i < ObstacleCount; i++)
        {
            ObstacleLastPosition = obstacles[i].SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }




    }

    private void OnTriggerEnter2D(Collider2D collision)//�ݸ����� �浹�� ���� �������� Ʈ���Ŵ� �뺸�� ����
    {
        //���� �浹�� �ֵ��� ������ �ٰ�

        if (collision.CompareTag("BackGround"))
        {
            float WidthofBackGround = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += WidthofBackGround * BackGroundCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); //Obstacle ��ũ��Ʈ �������ִ�?
        if (obstacle)
        {
            ObstacleLastPosition = obstacle.SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }



    }


}
