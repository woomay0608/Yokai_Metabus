using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    public float HighPostiony = 1f;
    public float LowPostiony = -1f;

    public float HoleSizemin = 1f;
    public float HoleSizemax = 3f;

    public Transform TopObject;
    public Transform BottomObject;

    public float WidthPadding = 4f;

    FlapyGameManager gameManager;

    private void Start()
    {
        gameManager = FlapyGameManager.FlapyGameManagers;
    }
    public Vector3 SetRandomPlace(Vector3 LastPosition, int ObstacleCount)
    {
        float holeSize = Random.Range(HoleSizemin, HoleSizemax);
        float halfholeSize = holeSize / 2;

        TopObject.localPosition = new Vector3(0, halfholeSize);
        BottomObject.localPosition = new Vector3(0, -halfholeSize);

        Vector3 PlacePosition = LastPosition + new Vector3(WidthPadding, 0);
        PlacePosition.y = Random.Range(LowPostiony, HighPostiony);

        transform.position = PlacePosition;

        return PlacePosition;

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        flapyPlayer player = collision.gameObject.GetComponent<flapyPlayer>();

        if (player != null) { gameManager.AddScore(1); }
    }
}
