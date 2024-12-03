using System.Collections.Generic;
namespace ShellSaver.Core {
	public static class ShellSaver {
		static readonly ISaver Saver = new JsonSaver();
		static readonly IPersistenceService Service = new CorePersistenceService(Saver);

		/// <summary>
		/// Save data to a file with the given name.
		/// </summary>
		/// <param name="data">The C# object to save</param>
		/// <param name="name">The name of the file without the extension</param>
		/// <param name="overwrite">Declares whether the file can be overwritten. If false, the file will not save</param>
		/// <typeparam name="T"></typeparam>
		public static void Save<T>(T data, string name, bool overwrite = true) => Service.Save(data, name, overwrite);
		/// <summary>
		/// Load data from a file with the given name.
		/// </summary>
		/// <param name="name">The name of the file without the extension</param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Load<T>(string name) => Service.Load<T>(name);
		/// <summary>
		/// Delete a file with the given name.
		/// </summary>
		/// <param name="name"></param>
		public static void Delete(string name) => Service.Delete(name);
		/// <summary>
		/// Clear all saved files.
		/// </summary>
		public static void Clear() => Service.Clear();
		/// <summary>
		/// List all saved files.
		/// </summary>
		/// <returns></returns>
		public static IEnumerable<string> ListSaves() => Service.ListSaves();
	}
}
