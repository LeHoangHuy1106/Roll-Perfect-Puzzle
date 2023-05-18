using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum Direction { positiveXAxis, negativeXAxis, positiveYAxis, negativeYAxis }
public class Pen : MonoBehaviour
{

    [SerializeField] private Image ink;
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private Transform tf;
    [SerializeField] private Color color;
    [SerializeField] private float speed = 2f;
    [SerializeField] private Direction direction;
    [SerializeField] private int index;
    [SerializeField] private GameObject pen;

    public Vector2 PosTarget { get; set; }
    private float newX;
    private float newY;

    public void SetPositionStart()
    {

        float rotationRad = rectTransform.rotation.eulerAngles.z * Mathf.Deg2Rad;
        switch (direction)
        {

            case Direction.positiveYAxis:
                newX = rectTransform.localPosition.x + rectTransform.rect.height * Mathf.Sin(rotationRad);
                newY = rectTransform.localPosition.y - rectTransform.rect.height * Mathf.Cos(rotationRad);
                break;
            case Direction.negativeYAxis:
                this.newX = rectTransform.localPosition.x - rectTransform.rect.height * Mathf.Sin(rotationRad);
                this.newY = rectTransform.localPosition.y + rectTransform.rect.height * Mathf.Cos(rotationRad);
                break;
            case Direction.positiveXAxis:
                newX = rectTransform.localPosition.x - rectTransform.rect.width * Mathf.Cos(rotationRad);
                newY = rectTransform.localPosition.y - rectTransform.rect.width * Mathf.Sin(rotationRad);
                break;
            case Direction.negativeXAxis:
                newX = rectTransform.localPosition.x + rectTransform.rect.width * Mathf.Cos(rotationRad);
                newY = rectTransform.localPosition.y + rectTransform.rect.width * Mathf.Sin(rotationRad);

                break;
        }
        rectTransform.localPosition = new Vector2(newX, newY);
    }
    private void Awake()
    {

        ink.color = color;
        SetPostionPen();
    }
    public int GetIndex()
    {
        return this.index;
    }


    public void SetParentTranform(Transform parent)
    {
        transform.SetParent(parent);
    }
    public void SetPostionPen()
    {
        switch (direction)
        {

            case Direction.positiveYAxis:
                newX = 0f;
                newY = rectTransform.rect.height / 2;
                break;
            case Direction.negativeYAxis:
                newX = 0f;
                newY = -rectTransform.rect.height / 2;
                break;
            case Direction.positiveXAxis:
                newX = rectTransform.rect.width / 2;
                newY = 0;
                break;
            case Direction.negativeXAxis:
                newX = -rectTransform.rect.width / 2;
                newY = 0;
                break;
        }
        pen.transform.localPosition = new Vector2(newX, newY);
    }
    public void Choose(Transform parent)
    {
        transform.SetParent(parent);
        pen.transform.SetParent(transform);
        pen.transform.rotation = transform.rotation;
        Moving(rectTransform.localPosition, PosTarget, 1f);
    }

    public void Moving(Vector2 start, Vector2 target, float time)
    {
        StartCoroutine(MoveToTarget(start, target, time));
    }
    private IEnumerator MoveToTarget(Vector2 start, Vector2 target, float time)
    {
        yield return new WaitForSeconds(0.3f);
        float startTime = Time.time;
        while (Time.time - startTime < time)
        {
            float t = (Time.time - startTime) / time;
            transform.localPosition = Vector3.Lerp(start, target, t);
            yield return null;
        }
        transform.localPosition = target;
        pen.SetActive(false);
    }

}
