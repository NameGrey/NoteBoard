
namespace NoteBoardAndroidApp.Models
{
	public class Note
	{
		public string Name { get; set; }

		public string GroupName { get; set; }

		public NoteGroup NoteGroup { get; set; }
	}
}