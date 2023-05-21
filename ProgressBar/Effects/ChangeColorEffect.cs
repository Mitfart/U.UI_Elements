using UnityEngine;
using UnityEngine.UI;

namespace UI.ProgressBar.Effects {
  public class ChangeColorEffect : ProgressBarEffect {
    [SerializeField] private Image    fill;
    [SerializeField] private Gradient gradient;
    [SerializeField] private bool     reverce;

    public override void OnBarChange(float newValue, float prevValue) {
      float evaluate = reverce ? 1 - newValue : newValue;
      fill.color = gradient.Evaluate(evaluate);
    }
  }
}