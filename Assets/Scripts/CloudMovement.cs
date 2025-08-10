using UnityEngine;

public class CloudMovement : MonoBehaviour
{
    [Header("Movimiento")]
    public bool loopMovement = true; // Si quieres que reaparezca
    public bool pingPongMovement = false; // Si quieres movimiento de ida y vuelta

    [Header("Parámetros de velocidad y distancia")]
    public float speed = 15f; // Velocidad (positivo = derecha, negativo = izquierda)
    public float moveDistance = 50f; // Solo para PingPong
    public float resetPositionX = -1000f; // X donde reaparece
    public float startPositionX = 1000f; // X inicial para reaparecer

    private RectTransform rectTransform;
    private Vector2 startPos;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        startPos = rectTransform.anchoredPosition;
    }

    void Update()
    {
        if (loopMovement)
        {
            rectTransform.anchoredPosition += Vector2.right * speed * Time.deltaTime;

            if (speed < 0 && rectTransform.anchoredPosition.x < resetPositionX)
            {
                rectTransform.anchoredPosition = 
                    new Vector2(startPositionX, rectTransform.anchoredPosition.y);
            }
            else if (speed > 0 && rectTransform.anchoredPosition.x > startPositionX)
            {
                rectTransform.anchoredPosition = 
                    new Vector2(resetPositionX, rectTransform.anchoredPosition.y);
            }
        }
        else if (pingPongMovement)
        {
            float offset = Mathf.Sin(Time.time * speed) * moveDistance;
            rectTransform.anchoredPosition = startPos + new Vector2(offset, 0);
        }
    }
}
