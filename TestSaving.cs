using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;
namespace ShellSaver.Core {
	public class TestSaving : MonoBehaviour {
		TestPlayerData player;
		void Update() {
			if (Keyboard.current.spaceKey.wasPressedThisFrame) {
				player = new() {
					Position = new Vector2(1, 2),
					Health = 100,
				};
				ShellSaver.Save(player, "Player");
			} else if (Keyboard.current.enterKey.wasPressedThisFrame) {
				player = ShellSaver.Load<TestPlayerData>("Player");
			}
		}
	}

	// classes that should be saved must be serializable
	[Serializable]
	public struct TestPlayerData {
		public Vector2 Position;
		public float Health;
	}
}
