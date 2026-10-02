using System.Text.RegularExpressions;

namespace ContextForge
{
    public record EntityCount(string Name, int Count);

    /// <summary>
    /// Finds the most common domain words (e.g. Order, Customer) in file and folder names.
    /// Names are split on PascalCase and separators, plurals are folded to singular,
    /// and technical words (Controller, Service, ViewModel...) are ignored.
    /// </summary>
    public static partial class EntityAnalyzer
    {
        private static readonly HashSet<string> StopWords = new(StringComparer.OrdinalIgnoreCase)
        {
            // Architecture / technical
            "controller", "service", "repository", "view", "model", "viewmodel", "page", "dto", "interface",
            "helper", "extension", "config", "configuration", "test", "base", "manager", "handler", "provider",
            "factory", "client", "api", "app", "data", "core", "common", "mobile", "web", "program", "startup",
            "appsettings", "json", "property", "properties", "resource", "constant", "util", "utility", "migration",
            "src", "main", "index", "readme", "design", "designer", "xaml", "resx", "csproj", "sln", "slnx",
            "assembly", "info", "global", "using", "launch", "setting", "request", "response", "result",
            "mapping", "mapper", "validator", "command", "query", "dialog", "form", "frm", "list", "detail",
            "item", "new", "edit", "create", "update", "delete", "get", "add", "remove", "component", "shared",
            "lib", "layout", "style", "asset", "script", "image", "icon", "font", "wwwroot", "platform",
            "android", "ios", "windows", "maccatalyst", "tizen", "raw", "splash", "package", "module", "dist",
            "build", "debug", "release", "bin", "obj", "git", "github", "workflow", "editorconfig", "gitignore",
            "exclusion", "context", "entity", "type", "enum", "event", "exception", "error", "option",
            // Plain English
            "and", "the", "for", "with", "from", "demo", "sample", "readme", "license", "changelog"
        };

        private static readonly HashSet<string> IgnoredFolders = new(StringComparer.OrdinalIgnoreCase)
        {
            "bin", "obj", ".git", ".vs", ".idea", "node_modules", "packages"
        };

        [GeneratedRegex(@"[A-Z]+(?![a-z])|[A-Z]?[a-z]+|\d+")]
        private static partial Regex WordPattern();

        public static List<EntityCount> GetTopEntities(string rootPath, IEnumerable<string> excludedDirectories, int top = 10)
        {
            var excluded = new HashSet<string>(excludedDirectories, StringComparer.OrdinalIgnoreCase);
            excluded.UnionWith(IgnoredFolders);

            // The project's own name (root folder and solution files) appears everywhere, so skip it.
            var projectWords = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            projectWords.UnionWith(ExtractWords(Path.GetFileName(rootPath.TrimEnd(Path.DirectorySeparatorChar))));
            foreach (var sln in Directory.EnumerateFiles(rootPath, "*.sln*", SearchOption.TopDirectoryOnly))
                projectWords.UnionWith(ExtractWords(StripExtensions(Path.GetFileName(sln))));

            var counts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);
            var displayNames = new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase);

            void CountName(string name)
            {
                // Each file/folder counts once per entity, even if the word repeats in its name.
                foreach (var word in ExtractWords(name).Distinct(StringComparer.OrdinalIgnoreCase))
                {
                    if (StopWords.Contains(word) || projectWords.Contains(word))
                        continue;

                    counts[word] = counts.GetValueOrDefault(word) + 1;
                    displayNames.TryAdd(word, char.ToUpperInvariant(word[0]) + word[1..]);
                }
            }

            void Walk(string dir)
            {
                IEnumerable<string> files, subDirs;
                try
                {
                    files = Directory.EnumerateFiles(dir).ToList();
                    subDirs = Directory.EnumerateDirectories(dir).ToList();
                }
                catch (UnauthorizedAccessException) { return; }
                catch (IOException) { return; }

                foreach (var file in files)
                    CountName(StripExtensions(Path.GetFileName(file)));

                foreach (var sub in subDirs)
                {
                    var name = Path.GetFileName(sub);
                    if (excluded.Contains(name) || name.StartsWith('.'))
                        continue;

                    CountName(name);
                    Walk(sub);
                }
            }

            Walk(rootPath);

            return counts
                .Where(kv => kv.Value > 1)
                .OrderByDescending(kv => kv.Value)
                .ThenBy(kv => kv.Key, StringComparer.OrdinalIgnoreCase)
                .Take(top)
                .Select(kv => new EntityCount(displayNames[kv.Key], kv.Value))
                .ToList();
        }

        private static IEnumerable<string> ExtractWords(string name)
        {
            foreach (Match m in WordPattern().Matches(name))
            {
                var word = m.Value;
                if (word.Length < 3 || char.IsDigit(word[0]))
                    continue;

                yield return Singularize(word);
            }
        }

        // "OrderViewModel.xaml.cs" -> "OrderViewModel"
        private static string StripExtensions(string fileName)
        {
            int dot = fileName.IndexOf('.', 1);
            return dot > 0 ? fileName[..dot] : fileName;
        }

        private static string Singularize(string word)
        {
            if (word.Length > 4 && word.EndsWith("ies", StringComparison.OrdinalIgnoreCase))
                return word[..^3] + "y";

            if (word.Length > 4 && (word.EndsWith("sses", StringComparison.OrdinalIgnoreCase)
                                 || word.EndsWith("xes", StringComparison.OrdinalIgnoreCase)
                                 || word.EndsWith("ches", StringComparison.OrdinalIgnoreCase)
                                 || word.EndsWith("shes", StringComparison.OrdinalIgnoreCase)))
                return word[..^2];

            if (word.Length > 3 && word.EndsWith('s')
                && !word.EndsWith("ss", StringComparison.OrdinalIgnoreCase)
                && !word.EndsWith("us", StringComparison.OrdinalIgnoreCase)
                && !word.EndsWith("is", StringComparison.OrdinalIgnoreCase))
                return word[..^1];

            return word;
        }
    }
}
