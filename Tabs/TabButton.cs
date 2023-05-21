using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UI.Tabs {
  [RequireComponent(typeof(Image))]
  public class TabButton
    : MonoBehaviour,
      IPointerEnterHandler,
      IPointerClickHandler,
      IPointerExitHandler {
    // ===================================================================

    [SerializeField] private TabGroup   tabGroup;
    [SerializeField] private GameObject tabContent;
    public                   Image      bg;

    // ===================================================================

    private void Start() {
      bg = GetComponent<Image>();
    }

    // ===================================================================

    private void OnEnable() {
      tabGroup.Subscribe(this);
    }

    private void OnDisable() {
      tabGroup.Unsubscribe(this);
    }

    // ===================================================================

    public void OnPointerClick(PointerEventData eventData) {
      tabGroup.OnTabClick(this);
    }

    public void OnPointerEnter(PointerEventData eventData) {
      tabGroup.OnTabEnter(this);
    }

    public void OnPointerExit(PointerEventData eventData) {
      tabGroup.OnTabExit(this);
    }

    // ===================================================================

    public void ActivateContext(bool active) {
      tabContent.SetActive(active);
    }
  }
}