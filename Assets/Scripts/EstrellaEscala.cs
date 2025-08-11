using UnityEngine;
using System.Collections;

public class EstrellaEscala : MonoBehaviour
{

    [SerializeField] Vector2 intervalRange;
    [SerializeField] float scaleFactor;
    [SerializeField] float durationTime;
    private Vector3 originalScale;
    private float randomInterval;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        randomInterval = Random.Range(intervalRange.x, intervalRange.y);
        originalScale = transform.localScale;
        StartCoroutine(Pulse());

    }

    IEnumerator Pulse (){
        while (true) {
            yield return new WaitForSeconds(randomInterval);
            yield return StartCoroutine(ChangeScale(originalScale, originalScale*scaleFactor, durationTime ));
            yield return StartCoroutine(ChangeScale(originalScale*scaleFactor, originalScale, durationTime ));
            
        }
    }

    IEnumerator ChangeScale (Vector3 startSize, Vector3 endSize, float duration ){

        float elapsedTime = 0f;
        while (elapsedTime<duration){
            float time = elapsedTime/duration;
            transform.localScale=Vector3.Lerp(startSize,endSize,time);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
        transform.localScale=endSize;
        
    }
}
