using Reflectis.SDK.Utilities;

using TMPro;

using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

namespace Reflectis.SDK.CreatorKit
{
    public class POIPlaceholder : SpawnAddressablePlaceholder
    {
        public enum ETitleVisibility
        {
            AlwaysHidden,
            VisibleOnHover,
            AlwaysVisible
        }

        [Space]
        [HelpBox("Quick guide on how to configure the content of a POI. " +
            "\n" + "\n" +
            "Elements of the POI: " +
            "\n" +
            "Panel: the body of the POI. A panel consists of one or more pages (see below) " +
            "and the navigation arrows to change the page. " +
            "To edit the dimensions of the panel, you can simply resize the width and height of " +
            "its RectTransform." +
            "\n" +
            "Activator: the button that opens/closes the panel of the POI." +
            "\n" +
            "Page: to add a page, you can simply duplicate the GameObject \"Page\" " +
            "as a child of the component \"Pages\". Note that the pages have the same dimensions, " +
            "which are inherited from the \"Panel\". " +
            "\n" +
            "Block: a page consists of one or more blocks. Those blocks can be added, moved and resized " +
            "within a page to add content to the POI. Note that a block cannot be positioned outside the " +
            "boundaries of the panel, otherwise it will not be visible due to masking. To edit the content " +
            "of a block, select the placeholder component provided in its prefab and follow the instructions.",
            HelpBoxMessageType.Info)]

        [Space]

        [Header("Read only references. Do no edit them.")]
        [SerializeField] private RectTransform activator;
        [SerializeField] private RectTransform title;
        [SerializeField] private RectTransform panel;
        [SerializeField] private RectTransform pagesContainer;
        [SerializeField] private RectTransform previousPage;
        [SerializeField] private RectTransform nextPage;
        [SerializeField] private Transform bindingLineStart;
        [SerializeField] private Transform bindingLineEnd;


        [Space]
        [Header("--- Configurable stuff starts here ---")]

        [Space]
        [Header("POI title configuration")]

        [SerializeField, Tooltip("Set the visibility of the title. " +
            "If AlwaysVisible, the title will always be visible. " +
            "If VisibleOnHover, the title will be visible only when hovering on the POI activator. " +
            "If AlwaysHidden, the title is deactivated")]
        private ETitleVisibility titleVisibility = ETitleVisibility.VisibleOnHover;

        [SerializeField, Tooltip("Set the text of the title.")]
        [OnChangedCall(nameof(OnPOITitleTextChanged))]
        private string titleText;

        [SerializeField, Tooltip("Change the font size of the title.")]
        [OnChangedCall(nameof(OnPOITitleFontChanged))]
        private float titleFontSize = 2;


        [Space]
        [Header("POI background configuration")]

        [HelpBox("By default the background is visible, but you can choose to hide it if you want to " +
            "arrange the content more freely in space. Be aware that, " +
            "even if the background is not visible, the content of the pages should not be placed outside " +
            "the boundaries of the panel, or they will not be visible due to masking.",
            HelpBoxMessageType.Info)]

        [SerializeField, Tooltip("Set the background visibility of the POI.")]
        [OnChangedCall(nameof(OnBackgroundVisibilityChanged))]
        private bool backgroundVisibility = true;


        [Space]
        [Header("POI binding line settings")]

        [HelpBox("A binding line can show that the POI is bound to something in space. " +
            "To change the line, change the position of \"LineStart\" and \"LineEnd\" transforms.",
            HelpBoxMessageType.Info)]

        [SerializeField, Tooltip("Choose whether to draw the binding line or not.")]
        private bool bindingLineVisibility;

        [SerializeField, Tooltip("The color of the binding line.")]
        private Color bindingLineColor = Color.red;

        [SerializeField, Tooltip("The width of the binding line.")]
        private float bindingLineWidth = 1f;


        [Space]
        [Header("POI audio settings")]

        [SerializeField, Tooltip("If set, the POI reproduces an audio clip while open")]
        private AudioClip audioClip;


        public RectTransform Activator => activator;
        public RectTransform Title => title;
        public RectTransform Panel => panel;
        public RectTransform PagesContainer => pagesContainer;
        public RectTransform PreviousPage => previousPage;
        public RectTransform NextPage => nextPage;
        public Transform BindingLineStart => bindingLineStart;
        public Transform BindingLineEnd => bindingLineEnd;

        public ETitleVisibility TitleVisibility => titleVisibility;
        public string TitleText => titleText;
        public float TitleFontSize => titleFontSize;

        public bool BackgroundVisibility => backgroundVisibility;

        public bool BindingLineVisibility => bindingLineVisibility;
        public Color BindingLineColor => bindingLineColor;
        public float BindingLineWidth => bindingLineWidth;

        public AudioClip AudioClip => audioClip;


        public void OnPOITitleTextChanged()
        {
#if UNITY_EDITOR
            SerializedObject so = new(title.GetComponentInChildren<TMP_Text>());
            so.FindProperty("m_text").stringValue = titleText;
            so.ApplyModifiedProperties();
#endif
        }

        public void OnPOITitleFontChanged()
        {
#if UNITY_EDITOR
            SerializedObject so = new(title.GetComponentInChildren<TMP_Text>());
            so.FindProperty("m_fontSize").floatValue = titleFontSize;
            so.ApplyModifiedProperties();
#endif
        }

        public void OnBackgroundVisibilityChanged()
        {
            panel.GetComponentInChildren<Image>().enabled = backgroundVisibility;
        }


        // This shows a preview of the binding line
        void OnDrawGizmosSelected()
        {
            if (bindingLineVisibility)
            {
                Gizmos.color = bindingLineColor;
                Gizmos.DrawLine(bindingLineStart.position, bindingLineEnd.position);
            }
        }
    }
}