using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[DisallowMultipleComponent]
public class TaskSystem : MonoBehaviour,IKey{

    [SerializeField]private KeyCode keyCode = KeyCode.T;

    [SerializeField][Range(0.1f, 2f)][Tooltip("变换的时间")]
    private float Duration=0.5f;

    [SerializeField][Range(0,1f)][Tooltip("等待的时间")]
    private float WaitTime = 0.02f;

    public GameObject TaskIconView;
    public GameObject TaskDescribeView;

    private bool isShowed = false;
    private float moveDistance;

    private Vector3 TaskNameViewDefaultPosition;
    private Vector3 TaskDescribeViewDefaultPosition;
    private Vector3 TaskNameViewTargetPosition { get { return TaskNameViewDefaultPosition - new Vector3(moveDistance, 0, 0); } }
    private Vector3 TaskDescribeViewTargetPosition { get { return TaskDescribeViewDefaultPosition - new Vector3(moveDistance, 0, 0); } }

    protected virtual void Awake() {
        isShowed = false;
        moveDistance= TaskIconView.GetComponent<RectTransform>().rect.width +
            TaskDescribeView.GetComponent<RectTransform>().rect.width;
        TaskNameViewDefaultPosition = TaskIconView.transform.localPosition;
        TaskDescribeViewDefaultPosition = TaskDescribeView.transform.localPosition;
    }

    protected virtual void Update() {
        if (Input.GetKeyDown(keyCode)) {
            ResponseKey();
        }
    }

    public virtual void SetKeyCode(KeyCode keyCode) {
        this.keyCode = keyCode;
    }
    public virtual KeyCode GetKeyCode() {
        return keyCode;
    }
    public virtual void ResponseKey() {
        isShowed = !isShowed;
        if (isShowed)
            StartCoroutine(Show());
        else StartCoroutine(Back());
    }

    protected virtual IEnumerator Show() {
        TaskIconView.SetActive(true);
        TaskDescribeView.SetActive(true);
        TaskIconView.transform.DOLocalMoveX(TaskNameViewTargetPosition.x, Duration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(WaitTime);
        TaskDescribeView.transform.DOLocalMoveX(TaskDescribeViewTargetPosition.x, Duration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(WaitTime);
    }

    protected virtual IEnumerator Back() {
        TaskIconView.transform.DOLocalMoveX(TaskNameViewDefaultPosition.x, Duration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(WaitTime);
        TaskDescribeView.transform.DOLocalMoveX(TaskDescribeViewDefaultPosition.x, Duration).SetEase(Ease.OutBack);
        yield return new WaitForSeconds(WaitTime);
        TaskIconView.SetActive(false);
        TaskDescribeView.SetActive(false);
    }

}
