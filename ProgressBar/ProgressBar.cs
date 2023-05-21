using System;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI.ProgressBar {
  public class ProgressBar : MonoBehaviour {
    // ==============================================================

    [SerializeField] private Image mask;

    [SerializeField][Range(0f, 1f)] private float value;

    public float PrevValue { get; protected set; }

    // ==============================================================

    public float Value {
      get => value;
      set {
        const float MIN_DIF = .000001f;
        if (Math.Abs(this.value - value) < MIN_DIF)
          return;

        if (value < 0 || (value > 1 && Mathf.Abs(value - 1) > MIN_DIF))
          Debug.LogWarning($"Value is not correct! \n {this} \n (value = {(double) value})");

        PrevValue  = this.value;
        this.value = Mathf.Clamp(value, 0, 1);
        UpdateView();
      }
    }

    public event Action<float, float> OnUpdate;



    private void OnValidate() {
      UpdateView();
    }

    // ==============================================================

    private void UpdateView() {
      if (mask.IsUnityNull())
        return;

      mask.fillAmount = Value;
      OnUpdate?.Invoke(Value, PrevValue);
    }

    // ==============================================================

#if UNITY_EDITOR
    private const string LINEAR_PATH = "UI/ProgressBar__Linear";
    private const string RADIAL_PATH = "UI/ProgressBar__Radial";

    [MenuItem("GameObject/UI/ProgressBar__Linear")]
    private static void CreateLinearPb() {
      GameObject ins = Instantiate(Resources.Load<GameObject>(LINEAR_PATH));
      UIUtils.InstantiateParentCanvas(ins);
    }

    [MenuItem("GameObject/UI/ProgressBar__Radial")]
    private static void CreateRadialPb() {
      GameObject ins = Instantiate(Resources.Load<GameObject>(RADIAL_PATH));
      UIUtils.InstantiateParentCanvas(ins);
    }
#endif

    // ==============================================================
  }
}