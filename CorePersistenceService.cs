using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
namespace ShellSaver.Core {
	public class CorePersistenceService : IPersistenceService {
		readonly ISaver saver;
		readonly string path, extension;
		public CorePersistenceService(ISaver saver, string extension = "json") {
			this.saver = saver;
			this.extension = extension;
			path = Application.persistentDataPath;
		}
		string GetPathToFile(string file) => Path.Combine(path, GetFile(file));
		string GetFile(string file) => string.Concat(file, ".", extension);
		public void Save<T>(T data, string name,bool overwrite = true) {
			var file = GetPathToFile(name);
			if (!overwrite && File.Exists(file)) throw new($"File {GetFile(name)} already exists and cannot be overwritten.");
			File.WriteAllText(file, saver.Save(data));
			Debug.Log($"Saved {name} to {file}");
		}
		public T Load<T>(string name) {
			var file = GetPathToFile(name);
			if (!File.Exists(file)) {
				Debug.LogError($"File {GetFile(name)} does not exist.");
				return default(T);
			}
			var save = saver.Load<T>(File.ReadAllText(file));
			Debug.Log($"Loaded {name} from {file}");
			return save;
		}
		public void Delete(string name) {
			var file = GetPathToFile(name);
			if (!File.Exists(file)) {
				Debug.LogError($"File {GetFile(name)} does not exist.");
			}
			File.Delete(file);
			Debug.Log($"Deleted {name} from {file}");
		}
		public void Clear() {
			foreach (var file in ListSaves()) File.Delete(file);
			Debug.Log($"Cleared all saves from {path}");
		}
		public IEnumerable<string> ListSaves() {
			return Directory.EnumerateFiles(path).Where(tempPath => Path.GetExtension(tempPath) == $".{extension}");
		}
	}
}
