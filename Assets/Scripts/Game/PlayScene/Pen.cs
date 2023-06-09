using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Game
{
    public class Pen : MonoBehaviour
    {

        [SerializeField] private Image ink;
        [SerializeField] private RectTransform rectTransform;
        [SerializeField] private Transform tf;
        [SerializeField] private Color color;
        [SerializeField] private float speed = 2f;
        [SerializeField] private int index;
        [SerializeField] private GameObject pen;
        [SerializeField] private GameObject penCopy;
        [SerializeField] private enumColor enumColor;

        public Vector2 PosTarget { get; set; }
        private float newX;
        private float newY;
        private Direction direction;

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
            penCopy.SetActive(false);
        }
        public int GetIndex()
        {
            return this.index;
        }

        public void SetSize(Vector2 size)
        {
            rectTransform.sizeDelta = new Vector2(size.x, size.y);
        }
        public void SetDirection(Direction direction)
        {
            this.direction = direction;
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
                    newY = Mathf.Abs(rectTransform.rect.height / 2);
                    //     pen.transform.localScale = new(1f, -1f);
                    break;
                case Direction.negativeYAxis:
                    newX = 0f;
                    newY = -Mathf.Abs(rectTransform.rect.height / 2);
                    break;
                case Direction.positiveXAxis:
                    //   pen.transform.localScale = new(-1f, 1f);
                    newX = Mathf.Abs(rectTransform.rect.width / 2);
                    newY = 0;
                    break;
                case Direction.negativeXAxis:
                    newX = -Mathf.Abs(rectTransform.rect.width / 2);
                    newY = 0;
                    break;
            }
            pen.transform.localPosition = new Vector2(newX, newY);


        }
        public void Choose(Transform answersTranform, Transform pensGroupTranform)
        {
            penCopy.SetActive(true);
            pen.SetActive(false);
            penCopy.transform.position = pen.transform.position;
            penCopy.transform.rotation = pen.transform.rotation;
            penCopy.transform.localScale = pen.transform.localScale;

            transform.SetParent(answersTranform);
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
            penCopy.SetActive(true);
            pen.SetActive(false);
            yield return new WaitForSeconds(0.3f);
            float startTime = Time.time;
            while (Time.time - startTime < time)
            {
                float t = (Time.time - startTime) / time;
                transform.localPosition = Vector3.Lerp(start, target, t);
                penCopy.transform.position = pen.transform.position;
                penCopy.transform.rotation = pen.transform.rotation;
                yield return null;
            }
            transform.localPosition = target;
            penCopy.SetActive(false);
        }
    }
}