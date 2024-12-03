namespace ShellSaver.Core {
	// the ISaver interface is for classes that can save and load some form of data (marked by the generic)
	public interface ISaver {
		string Save<T>(T data);
		T Load<T>(string data);
	}
}
