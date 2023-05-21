using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Tooltip {
  [ExecuteInEditMode]
  public class Tooltip : MonoBehaviour {
    // ====================================================================
    public Canvas canvas;

    [SerializeField] private TextMeshProUGUI header;
    [SerializeField] private TextMeshProUGUI content;
    [SerializeField] private LayoutElement   layoutElement;

    [SerializeField] private int charLimit;

    [HideInInspector] public RectTransform rect;

    // ====================================================================

    private void Awake() {
      rect = GetComponent<RectTransform>();
    }

#if UNITY_EDITOR
    private void Update() {
      UpdateView();
    }
#endif

    // ====================================================================

    public void SetContext(Context context) {
      header.text  = context.title;
      content.text = context.text;

      if (string.IsNullOrWhiteSpace(header.text))
        header.gameObject.SetActive(false);
      if (string.IsNullOrWhiteSpace(content.text))
        content.gameObject.SetActive(false);

      UpdateView();
    }

    private void UpdateView() {
      float headerLength  = header  == null ? 0f : header.text.Length;
      float contentLength = content == null ? 0f : content.text.Length;

      if (layoutElement != null)
        layoutElement.enabled = headerLength > charLimit || contentLength > charLimit;
    }

    // ====================================================================

    [Serializable]
    public struct Context {
      public string title;
      public string text;

      public Context(string title, string text) {
        this.title = title;
        this.text  = text;
      }
    }

    // ====================================================================
  }
}