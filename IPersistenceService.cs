using System.Collections.Generic;
namespace ShellSaver.Core {
	// the IPersistenceService interface is for classes that will handle the higher-level saving, loading, deleting, and listing of saves
	// it does not handle the actual saving and loading of data, that is done by the ISaver interface
	public interface IPersistenceService {
		void Save<T>(T data, string name, bool overwrite = true);
		T Load<T>(string name);
		void Delete(string name);
		void Clear();
		IEnumerable<string> ListSaves();
	}
}
