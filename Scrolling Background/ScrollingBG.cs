using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.Scrolling_Background {
  [RequireComponent(typeof(RawImage))]
  public class ScrollingBg : MonoBehaviour {
    // ==============================================================

    [SerializeField] private Vector2 direction;
    [SerializeField] private float   speed;

    private RawImage _image;

    // ==============================================================

    private void Awake() {
      _image = GetComponent<RawImage>();
    }


    private void Update() {
      _image.uvRect = new Rect(
        _image.uvRect.position + direction * speed * Time.deltaTime,
        _image.uvRect.size
      );
    }

    // ==============================================================

    private void OnValidate() {
      direction = direction.normalized;
      speed     = Mathf.Abs(speed);
    }

    // ==============================================================

#if UNITY_EDITOR
    private const string PATH = "UI/ScrollingBG";

    [MenuItem("GameObject/UI/ScrollingBG")]
    private static void CreateLinearPb() {
      GameObject ins = Instantiate(Resources.Load<GameObject>(PATH));
      UIUtils.InstantiateParentCanvas(ins);
    }
#endif

    // ==============================================================
  }
}