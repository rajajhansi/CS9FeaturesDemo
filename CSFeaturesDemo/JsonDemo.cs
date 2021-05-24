using System;
using System.Buffers;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CSFeaturesDemo
{
    public class JsonDemo
    {
        public static void Utf8JsonReaderDemo()
        {
            Console.WriteLine("Utf8JsonReader Sample");
            var jsonBytes = Encoding.UTF8.GetBytes(File.ReadAllText("sample.json", new UTF8Encoding()));
            var jsonSpan = jsonBytes.AsSpan();
            var json = new Utf8JsonReader(jsonSpan);

            while (json.Read())
            {
                Console.WriteLine(GetTokenDesc(json));
            }
        }

        private static string GetTokenDesc(Utf8JsonReader json) =>
            json.TokenType switch
            {
                JsonTokenType.StartObject => "START OBJECT",
                JsonTokenType.EndObject => "END OBJECT",
                JsonTokenType.StartArray => "START ARRAY",
                JsonTokenType.EndArray => "END ARRAY",
                JsonTokenType.PropertyName => $"PROPERTY {json.GetString()}",
                JsonTokenType.Comment => $"COMMENT: {json.GetString()}",
                JsonTokenType.String => $"STRING: {json.GetString()}",
                JsonTokenType.Number => $"NUMBER: {json.GetInt32()}",
                JsonTokenType.True => $"BOOL: {json.GetBoolean()}",
                JsonTokenType.False => $"BOOL: {json.GetBoolean()}",
                JsonTokenType.Null => $"NULL",
                _ => $"UNHANDLED TOKEN: {json.TokenType}"
            };

        public static void JsonDocumentDemo()
        {
            Console.WriteLine("JsonDocument Demo");
            using var stream = File.OpenRead("sample.json");
            using var doc = JsonDocument.Parse(stream);

            var root = doc.RootElement;
            var firstName = root
                .GetProperty("author")
                .GetProperty("firstName")
                .GetString();
            Console.WriteLine($"Author first name: {firstName}");
            EnumerateElement(root);
        }

        private static void EnumerateElement(JsonElement root)
        {
            foreach (var prop in root.EnumerateObject())
            {
                if (prop.Value.ValueKind == JsonValueKind.Object)
                {
                    Console.WriteLine($"{prop.Name}");
                    Console.WriteLine($"--BEGIN OBJECT--");
                    EnumerateElement(prop.Value);
                    Console.WriteLine($"--END OBJECT--");
                }
                else
                {
                    Console.WriteLine($"{prop.Name}: {prop.Value.GetRawText()}");
                }
            }
        }

        public static void JsonWriterDemo()
        {
            Console.WriteLine("JsonWriter Demo");
            var options = new JsonWriterOptions
            {
                Indented = true
            };
            var buffer = new ArrayBufferWriter<byte>();
            using var json = new Utf8JsonWriter(buffer, options);

            PopulateJson(json);
            json.Flush();

            var output = buffer.WrittenSpan.ToArray();
            var ourJson = Encoding.UTF8.GetString(output);
            Console.WriteLine(ourJson);
        }

        private static void PopulateJson(Utf8JsonWriter json)
        {
            json.WriteStartObject();
            json.WritePropertyName("courseName");
            json.WriteStringValue("Build Your Own Application Framework");

            json.WriteString("language", "C#");

            json.WriteStartObject("author");

            json.WriteString("firstName", "Raja");
            json.WriteString("lastName", "Mani");
            json.WriteEndObject();
            json.WriteEndObject();
        }

        public static void JsonSerializerDemo()
        {
            Console.WriteLine("JsonSerializer Demo");
            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                WriteIndented = true
            };

            var text = File.ReadAllText("sample.json");
            var course = JsonSerializer.Deserialize<Course>(text, options);

            //Console.WriteLine($"Course name: {course.CourseName}");
            //Console.WriteLine($"Author: {course.Author.FirstName} " +
            //     $"{course.Author.LastName}");

            Console.WriteLine(JsonSerializer.Serialize(course, options));
        }
    }

    public class Course
    {
        public string CourseName { get; set; }
        public string Language { get; set; }
        public Author Author { get; set; }
        public DateTime PublishedAt { get; set; }
        public int PublishedYear { get; set; }
        public bool IsActive { get; set; }
        public string[] Tags { get; set; }
    }

    public class Author
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}