using UnityEngine;

namespace UI.ProgressBar.Effects {
  [RequireComponent(typeof(ProgressBar))]
  public abstract class ProgressBarEffect : MonoBehaviour {
    [SerializeField] protected ProgressBar bar;

    protected virtual void OnEnable() {
      bar.OnUpdate += OnBarChange;
    }

    protected virtual void OnDisable() {
      bar.OnUpdate -= OnBarChange;
    }


    public abstract void OnBarChange(float newValue, float prevValue);
  }
}