#if UNITY_EDITOR

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using DG.Tweening;

[CustomEditor(typeof(UITweening))]
public class UITweeningEditor : Editor
{
    private UITweening _tweening;

    private bool sizeDelta = false;
    private bool scale = false;
    private bool tMPTextColor = false;
    private bool imageColor = false;

    private void OnEnable() => _tweening = target as UITweening;

    public override void OnInspectorGUI()
    {
        _tweening.whenDo = (UITweeningType)EditorGUILayout.EnumPopup("When Do", _tweening.whenDo);
        _tweening.tweeningDelay = EditorGUILayout.FloatField("Delay", _tweening.tweeningDelay);

        EditorGUILayout.Space(10);

        EditorGUILayout.BeginHorizontal();
        if (GUILayout.Button("Size Delta")) sizeDelta = ActivateTab();
        if (GUILayout.Button("Scale")) scale = ActivateTab();
        if (GUILayout.Button("TMP Text Color")) tMPTextColor = ActivateTab();
        if (GUILayout.Button("Image Color")) imageColor = ActivateTab();
        EditorGUILayout.EndHorizontal();

        EditorGUILayout.Space(10);

        if (sizeDelta) SizeDeltaTab();
        else if (scale) ScaleTab();
        else if (tMPTextColor) TMPTextColorTab();
        else if (imageColor) ImageColorTab();

        EditorGUILayout.Space();

        EditorGUILayout.PropertyField(this.serializedObject.FindProperty("_onBegin"), true);
    }

    private void SizeDeltaTab()
    {
        EditorGUILayout.LabelField("Size Delta");

        EditorGUILayout.Space();

        _tweening.doSizeDelta = EditorGUILayout.Toggle("Do", _tweening.doSizeDelta);
        _tweening.startSizeDelta = EditorGUILayout.Vector2Field("Start", _tweening.startSizeDelta);
        _tweening.endSizeDelta = EditorGUILayout.Vector2Field("End", _tweening.endSizeDelta);
        _tweening.durationSizeDelta = EditorGUILayout.FloatField("Duration", _tweening.durationSizeDelta);
        _tweening.easeSizeDelta = (Ease)EditorGUILayout.EnumPopup("Ease", _tweening.easeSizeDelta);
    }
    private void ScaleTab()
    {
        EditorGUILayout.LabelField("Scale");

        EditorGUILayout.Space();

        _tweening.doScale = EditorGUILayout.Toggle("Do", _tweening.doScale);
        _tweening.startScale = EditorGUILayout.Vector2Field("Start", _tweening.startScale);
        _tweening.endScale = EditorGUILayout.Vector2Field("End", _tweening.endScale);
        _tweening.durationScale = EditorGUILayout.FloatField("Duration", _tweening.durationScale);
        _tweening.easeScale = (Ease)EditorGUILayout.EnumPopup("Ease", _tweening.easeScale);
    }
    private void TMPTextColorTab()
    {
        EditorGUILayout.LabelField("TMP Text Color");

        EditorGUILayout.Space();

        _tweening.doTextColor = EditorGUILayout.Toggle("Do", _tweening.doTextColor);
        _tweening.startTextColor = EditorGUILayout.ColorField("Start", _tweening.startTextColor);
        _tweening.endTextColor = EditorGUILayout.ColorField("End", _tweening.endTextColor);
        _tweening.durationTextColor = EditorGUILayout.FloatField("Duration", _tweening.durationTextColor);
        _tweening.easeTextColor = (Ease)EditorGUILayout.EnumPopup("Ease", _tweening.easeTextColor);
    }
    private void ImageColorTab()
    {
        EditorGUILayout.LabelField("Image Color");

        EditorGUILayout.Space();

        _tweening.doImageColor = EditorGUILayout.Toggle("Do", _tweening.doImageColor);
        _tweening.startImageColor = EditorGUILayout.ColorField("Start", _tweening.startImageColor);
        _tweening.endImageColor = EditorGUILayout.ColorField("End", _tweening.endImageColor);
        _tweening.durationImageColor = EditorGUILayout.FloatField("Duration", _tweening.durationImageColor);
        _tweening.easeImageColor = (Ease)EditorGUILayout.EnumPopup("Ease", _tweening.easeImageColor);
    }

    private bool ActivateTab()
    {
        sizeDelta = false;
        scale = false;
        tMPTextColor = false;
        imageColor = false;

        return true;
    }
}

#endif