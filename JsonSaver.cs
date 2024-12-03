using UnityEngine;
namespace ShellSaver.Core {
	public class JsonSaver : ISaver {
		public string Save<T>(T data) => JsonUtility.ToJson(data, true);
		public T Load<T>(string data) => JsonUtility.FromJson<T>(data);
	}
}
