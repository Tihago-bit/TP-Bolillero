# TP-Bolillero
Hola 
 el tp bolillero es un tp de un bolillero 
namespace Dominio.Tests
{
    public class ReIngresar_ReadmeTests
    {
        private string FindReadme()
        {
            var dir = new System.IO.DirectoryInfo(System.AppContext.BaseDirectory);
            for (int i = 0; i < 10; i++)
            {
                var candidate = System.IO.Path.Combine(dir.FullName, "README.md");
                if (System.IO.File.Exists(candidate)) return candidate;
                if (dir.Parent == null) break;
                dir = dir.Parent;
            }
            return null;
        }

        [Xunit.Fact]
        public void ReadmeExists()
        {
            var path = FindReadme();
            Xunit.Assert.False(string.IsNullOrEmpty(path), $"README.md no encontrado empezando en {System.AppContext.BaseDirectory}");
            Xunit.Assert.True(System.IO.File.Exists(path), "README.md debería existir en el árbol de directorios del proyecto.");
        }

        [Xunit.Fact]
        public void ReadmeContainsExpectedText()
        {
            var path = FindReadme();
            Xunit.Assert.False(string.IsNullOrEmpty(path), "README.md no encontrado");
            var content = System.IO.File.ReadAllText(path);
            var lower = content.ToLowerInvariant();

            Xunit.Assert.Contains("# TP-Bolillero", content);
            Xunit.Assert.Contains("tp bolillero es un tp de un bolillero", lower);
        }
    }
}

