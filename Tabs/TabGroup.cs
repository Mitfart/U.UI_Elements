using System.Collections.Generic;
using UnityEngine;

namespace UI.Tabs {
  public class TabGroup : MonoBehaviour {
    [SerializeField] private Sprite tabIdle;
    [SerializeField] private Sprite tabHover;

    [SerializeField] private Sprite tabActive;

    private TabButton _activeTab;

    // ===================================================================

    private List<TabButton> _tabButtons;

    // ===================================================================

    public void Subscribe(TabButton button) {
      _tabButtons ??= new List<TabButton>();

      _tabButtons.Add(button);
    }

    public void Unsubscribe(TabButton tabButton) {
      _tabButtons.Remove(tabButton);
    }

    // ===================================================================

    public void OnTabClick(TabButton tab) {
      _activeTab = tab;
      ResetTabs();
      tab.bg.sprite = tabActive;
    }

    public void OnTabEnter(TabButton tab) {
      ResetTabs();
      if (tab != _activeTab)
        tab.bg.sprite = tabHover;
    }

    public void OnTabExit(TabButton tab) {
      ResetTabs();
      tab.bg.sprite = tabIdle;
    }

    public void ResetTabs() {
      foreach (TabButton tabButton in _tabButtons) {
        if (tabButton != _activeTab) {
          tabButton.bg.sprite = tabIdle;
          tabButton.ActivateContext(false);
        }
        else {
          tabButton.bg.sprite = tabActive;
          tabButton.ActivateContext(true);
        }
      }
    }

    // ===================================================================
  }
}