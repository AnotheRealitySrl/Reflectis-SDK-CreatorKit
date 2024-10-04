using Reflectis.SDK.Utilities;

using System;

using TMPro;

using UnityEditor;

using UnityEngine;

namespace Reflectis.SDK.CreatorKit
{
    [Serializable]
    public class POITextPlaceholder : POIBlockPlaceholder
    {
        public enum EPOITextFontStyle
        {
            Normal,
            Bold
        }

        [Space]
        [Header("Configurable stuff")]

        [SerializeField, Tooltip("Configure the text that will be shown.")]
        [OnChangedCall(nameof(OnTextChanged))]
        private string text;

        [SerializeField, Tooltip("Change the font size.")]
        [OnChangedCall(nameof(OnFontSizeChanged))]
        private float fontSize;

        [SerializeField, Tooltip("Change the font width.")]
        [OnChangedCall(nameof(OnFontWidthChanged))]
        private EPOITextFontStyle fontWidth;

        public string Text => text;
        public float FontSize => fontSize = 1f;
        public EPOITextFontStyle FontWidth => fontWidth;


        public void OnTextChanged()
        {
#if UNITY_EDITOR
            SerializedObject so = new(transform.GetComponentInChildren<TMP_Text>());
            so.FindProperty("m_text").stringValue = text;
            so.ApplyModifiedProperties();
#endif
        }

        public void OnFontSizeChanged()
        {
#if UNITY_EDITOR
            SerializedObject so = new(transform.GetComponentInChildren<TMP_Text>());
            so.FindProperty("m_fontSize").floatValue = fontSize;
            so.ApplyModifiedProperties();
#endif
        }

        public void OnFontWidthChanged()
        {
#if UNITY_EDITOR
            SerializedObject so = new(transform.GetComponentInChildren<TMP_Text>());
            so.FindProperty("m_fontStyle").enumValueFlag = fontWidth == EPOITextFontStyle.Bold ? (int)FontStyles.Bold : (int)FontStyles.Normal;
            so.ApplyModifiedProperties();
#endif
        }
    }
}