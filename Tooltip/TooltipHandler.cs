using UnityEngine;

namespace UI.Tooltip {
  public class TooltipHandler : MonoBehaviour {
    [SerializeField] private Tooltip tooltip;

    private void Start() {
      tooltip.canvas.gameObject.SetActive(false);
    }

    public void Show(Tooltip.Context context) {
      tooltip.canvas.gameObject.SetActive(true);
      tooltip.SetContext(context);
    }

    public void Hide() {
      tooltip.canvas.gameObject.SetActive(false);
    }

    public void SetTooltipPos(Vector2 position) {
      float picotX = position.x / Screen.width;
      float picotY = position.y / Screen.height;

      tooltip.rect.pivot         = new Vector2(picotX, picotY);
      tooltip.transform.position = position;
    }
  }
}