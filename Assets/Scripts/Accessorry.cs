using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accessorry : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private bool IsTouch = false;
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Pivot Pivot;

    [SerializeField] private int AcceId;

    private void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!IsTouch)
        {
            UiManager.Instace.IsFind[AcceId] = true;
            this.gameObject.SetActive(false);
            UiManager.Instace.ShowAcces();
        }
        
    }

    public void Equip()
    {
       Pivot.Sprite.sprite  = sprite.sprite;
    }
}
