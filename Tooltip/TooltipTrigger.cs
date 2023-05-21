using UnityEngine;
using UnityEngine.EventSystems;
using Utils;

namespace UI.Tooltip {
  public class TooltipTrigger : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerMoveHandler {
    // ====================================================================

    [SerializeField] private Tooltip.Context context;
    [SerializeField] private TooltipHandler  tooltipHandler;

    public void Update() {
      SetPos(MouseUtils.Pos());
    }

    public void OnMouseEnter() {
      Show();
    }

    // ====================================================================

    public void OnMouseExit() {
      Hide();
    }

    // ====================================================================

    public void OnPointerEnter(PointerEventData eventData) {
      Show();
    }

    public void OnPointerExit(PointerEventData eventData) {
      Hide();
    }

    public void OnPointerMove(PointerEventData eventData) {
      SetPos(eventData.position);
    }

    // ====================================================================

    private void Show() {
      tooltipHandler.Show(context);
    }

    private void Hide() {
      tooltipHandler.Hide();
    }

    private void SetPos(Vector2 position) {
      tooltipHandler.SetTooltipPos(position);
    }

    // ====================================================================
  }
}