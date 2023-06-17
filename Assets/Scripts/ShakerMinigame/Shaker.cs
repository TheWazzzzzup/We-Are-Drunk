using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class Shaker : MonoBehaviour , IPointerDownHandler
{
    [SerializeField] Rigidbody2D rb2;
    [SerializeField] float maxX;
    [SerializeField] float minHeight;
    [SerializeField] float maxHeight;

    int shakerClickCount = 0;

    float rndX;
    float rndY;

    public void OnPointerDown(PointerEventData eventData)
    {
        ShakerClicked();
    }

    private void Awake()
    {
        rb2.simulated = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb2.simulated = true;
        }
    }

    void ShakerClicked()
    {
        shakerClickCount++;
        rndX = Random.Range(-maxX, maxX);
        rndY = Random.Range(minHeight, maxHeight);

        float rndRot = Random.Range(-270, 270);

        transform.DORotate(new Vector3(0, 0, rndRot), 2f);

        rb2.velocity = new Vector2(rndX, rndY);
    }

    
}
