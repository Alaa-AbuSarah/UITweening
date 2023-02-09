using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.Events;
using TMPro;

[RequireComponent(typeof(RectTransform))]
public class UITweening : MonoBehaviour
{
    #region Settings
    public UITweeningType whenDo = UITweeningType.OnEnable;
    public float tweeningDelay = 0f;
    #endregion

    #region Size Delta
    public bool doSizeDelta = false;
    public Vector2 startSizeDelta = Vector2.zero;
    public Vector2 endSizeDelta = Vector2.one;
    public float durationSizeDelta = 0.25f;
    public Ease easeSizeDelta = Ease.Linear;
    #endregion

    #region Scale
    public bool doScale = false;
    public Vector3 startScale = Vector3.zero;
    public Vector3 endScale = Vector3.one;
    public float durationScale = 0.25f;
    public Ease easeScale = Ease.Linear;
    #endregion

    #region TMP Text Color
    public bool doTextColor = false;
    public Color startTextColor = new Color(1, 1, 1, 0);
    public Color endTextColor = Color.white;
    public float durationTextColor = 0.25f;
    public Ease easeTextColor = Ease.Linear;
    private TMP_Text _text;
    #endregion

    #region Image Color
    public bool doImageColor = false;
    public Color startImageColor = new Color(1, 1, 1, 0);
    public Color endImageColor = Color.white;
    public float durationImageColor = 0.25f;
    public Ease easeImageColor = Ease.Linear;
    private Image _image;
    #endregion

    #region Event
    public UnityEvent _onBegin;
    #endregion

    #region Private Variables
    private RectTransform _rect;
    #endregion

    private void Awake()
    {
        _rect = GetComponent<RectTransform>();

        if (doTextColor) _text = GetComponent<TMP_Text>();
        if (doImageColor) _image = GetComponent<Image>();
    }

    private void Start()
    {
        if (whenDo == UITweeningType.OnStart) Tweening();
    }

    private void OnEnable()
    {
        if (whenDo == UITweeningType.OnEnable) Tweening();
    }

    public void Do()
    {
        if (whenDo == UITweeningType.OnRequest) Tweening();
    }

    private void Tweening()
    {
        _onBegin.Invoke();

        if (doSizeDelta)
        {
            _rect.anchoredPosition = startSizeDelta;
            _rect.DOAnchorPos(endSizeDelta, durationSizeDelta).SetEase(easeSizeDelta).SetDelay(tweeningDelay);
        }

        if (doScale)
        {
            _rect.localScale = startScale;
            _rect.DOScale(endScale, durationScale).SetEase(easeScale).SetDelay(tweeningDelay);
        }

        if (doTextColor)
        {
            _text.color = startTextColor;
            _text.DOColor(endTextColor, durationTextColor).SetEase(easeTextColor).SetDelay(tweeningDelay);
        }

        if (doImageColor)
        {
            _image.color = startImageColor;
            _image.DOColor(endImageColor, durationImageColor).SetEase(easeImageColor).SetDelay(tweeningDelay);
        }
    }
}
