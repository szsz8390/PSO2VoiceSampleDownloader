using System.Net;

// txt file format
// [Item Name]	[Voice Actor]	[Sample Voice 1 css class name]	[Sample Voice 2 css class name]	[Sample Voice 3 css class name]
const string t1file = "pso2_voice_t1.txt";
const string t2file = "pso2_voice_t2.txt";
const string t1cfile = "pso2_voice_t1c.txt";
const string t2cfile = "pso2_voice_t2c.txt";

string curDir = System.Environment.CurrentDirectory;

string[] fileNames = { t1file, t2file, t1cfile, t2cfile };
string[] typeNames = { "Human Type 1", "Human Type 2", "CAST Type 1", "CAST Type 2" };

HttpClient httpClient = new HttpClient();

for (var i = 1; i < fileNames.Length; i++)
{
    string typeName = typeNames[i];
    string path = Path.Combine(curDir, fileNames[i]);
    Console.WriteLine(path);
    if (File.Exists(path))
    {
        string typeDirPath = Path.Combine(curDir, typeName);
        string[] lines = File.ReadAllLines(path);
        Directory.CreateDirectory(Path.Combine(curDir, typeName));
        foreach (var line in lines)
        {
            if (string.IsNullOrWhiteSpace(line)) { continue; }
            string[] parts = line.Split("\t");
            if (parts.Length != 5) { continue; }
            Console.WriteLine("Process Item Name: " + parts[0]);
            string voice1 = parts[2];
            string voice2 = parts[3];
            string voice3 = parts[4];
            string[] voices = { voice1, voice2, voice3 };
            int dlCount = 0;
            foreach (var voice in voices)
            {
                Console.WriteLine("    voice class name: " + voice);
                string voiceFilePath = Path.Combine(typeDirPath, voice + ".ogg");
                if (File.Exists(voiceFilePath))
                {
                    Console.WriteLine("    file already exists. skip it.");
                    continue;
                }
                using (var request = new HttpRequestMessage(HttpMethod.Get, new Uri("https://pso2.jp/players/catalog/audio/" + voice + ".ogg")))
                using (var response = await httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead))
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        using (var content = response.Content)
                        using (var stream = await content.ReadAsStreamAsync())
                        using (var fileStream = new FileStream(voiceFilePath, FileMode.Create, FileAccess.Write, FileShare.None))
                        {
                            Console.WriteLine("    downloaded!");
                            stream.CopyTo(fileStream);
                            dlCount++;
                        }
                    }
                }
            }
            if (dlCount > 0)
            {
                Thread.Sleep(3000);
            }
        }


    }
}
