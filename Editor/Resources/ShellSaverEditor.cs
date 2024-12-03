using System;
using System.IO;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace ShellSaver.Editor {
	public class ShellSaverEditor : EditorWindow {
		Button refreshButton, openPathButton;
		ScrollView view;

		[MenuItem("Tools/Shell Saver")]
		public static void OpenWindow() {
			var window = GetWindow<ShellSaverEditor>();
			window.titleContent = new("Shell Saver");
			// enforce window constraints
			window.maxSize = new Vector2(500, 600);
		}

		void CreateGUI() {
			var root = rootVisualElement;
			var visualTree = AssetDatabase.LoadAssetAtPath<VisualTreeAsset>("Assets/Shell Saver/Editor/Resources/ShellSaverWindow.uxml");
			var tree = visualTree.Instantiate();

			root.Add(tree);

			refreshButton = root.Q<Button>("RefreshButton");
			openPathButton = root.Q<Button>("OpenPathButton");
			view = root.Q<ScrollView>("ScrollView");

			Refresh(view);

			refreshButton.clickable.clicked += () => Refresh(view);
			openPathButton.clickable.clicked += OpenPath;
		}

		static void Refresh(ScrollView view) {
			// every time we refresh, we clear the view and re-add the buttons. otherwise, we'd have duplicates
			view.Clear();
			foreach (var save in Core.ShellSaver.ListSaves()) {
				// delete the save and reload
				var button = new Button(() => {
					Application.OpenURL(save);
					Refresh(view);
				}) {
					text = save,
				};
				view.Add(button);
			}
		}

		static void OpenPath() {
			Application.OpenURL(Application.persistentDataPath);
		}
	}
}
