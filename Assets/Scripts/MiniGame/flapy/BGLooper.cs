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

    private void OnTriggerEnter2D(Collider2D collision)//콜리전은 충돌에 대한 정보지만 트리거는 통보만 해줌
    {
        //나랑 충돌한 애들의 정보를 줄게

        if (collision.CompareTag("BackGround"))
        {
            float WidthofBackGround = ((BoxCollider2D)collision).size.x;
            Vector3 pos = collision.transform.position;
            pos.x += WidthofBackGround * BackGroundCount;
            collision.transform.position = pos;
            return;
        }

        Obstacle obstacle = collision.GetComponent<Obstacle>(); //Obstacle 스크립트 가지고있니?
        if (obstacle)
        {
            ObstacleLastPosition = obstacle.SetRandomPlace(ObstacleLastPosition, ObstacleCount);
        }



    }


}
