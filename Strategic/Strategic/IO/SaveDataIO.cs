using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Game;

namespace App.IO
{
    public class SaveDataIO
    {
        private static readonly JsonSerializerOptions options = new() { WriteIndented = true };

        public async static void Write(BattleField battleField, string fileName)
        {
            using FileStream createStream = File.Create(fileName);
            await JsonSerializer.SerializeAsync<BattleField>(createStream, battleField, options);
            await createStream.DisposeAsync();
        }

        public async static Task<(bool, BattleField?)> Read(string fileName)
        {
            using FileStream openStream = File.OpenRead(fileName);
            // ここを変える
            BattleField? battleField = await JsonSerializer.DeserializeAsync<BattleField>(openStream, options);
            return (battleField != null, battleField);
        }

        public static (bool, BattleField?) ReadSync(string fileName)
        {
            using FileStream openStream = File.OpenRead(fileName);
            BattleField? battleField = JsonSerializer.Deserialize<BattleField>(openStream, options);
            return (battleField != null, battleField);
        }
    }
}
