#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

namespace UI {
  public static class UIUtils {
    private const string CANVAS = "Canvas";



    public static void InstantiateParentCanvas(this GameObject uiElement) => uiElement.transform.SetParent(Parent(), false);

    private static Transform Parent() => HasCanvasInParents(Root()) ? Root() : CreateCanvas().transform;



    private static bool HasCanvasInParents(Transform root) {
      Transform parent = root;

      while (parent != null) {
        if (parent.TryGetComponent(out Canvas _))
          return true;

        parent = parent.parent;
      }

      return false;
    }

    private static Canvas CreateCanvas() {
      Canvas newCanvas = new GameObject(CANVAS).AddComponent<Canvas>();
      newCanvas.transform.SetParent(Selection.activeGameObject.transform, false);
      return newCanvas;
    }



    private static Transform Root() => Selection.activeGameObject.transform;
  }
}
#endif