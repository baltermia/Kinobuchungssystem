using System.IO;

namespace Kinobuchungssystem
{
    class Controller
    {
        public readonly SimpleCollection<Cinema> Cinemas;

        public Controller()
        {
            Cinemas = new SimpleCollection<Cinema>();
        }

        public Controller(string path)
        {
            Cinemas = SimpleCollection<Cinema>.GetDeserialized(File.ReadAllText(path));
        }

        public void Save(string path)
        {
            File.WriteAllText(path, Cinemas.GetSerialized());
        }
    }
}
