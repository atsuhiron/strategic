using System.IO;
using System.Threading.Tasks;
using System.Text.Json;
using Game;
using App.Constants;

namespace App.IO
{
    public class SaveDataIO
    {
        public async static void Write(BattleField battleField, string fileName)
        {
            using FileStream createStream = File.Create(Paths.saveDataDir + fileName);
            await JsonSerializer.SerializeAsync<BattleField>(createStream, battleField);
            await createStream.DisposeAsync();
        }

        public async static Task<(bool, BattleField?)> Read(string fileName)
        {
            using FileStream openStream = File.OpenRead(Paths.saveDataDir + fileName);
            BattleField? battleField = await JsonSerializer.DeserializeAsync<BattleField>(openStream);
            return (battleField == null, battleField);
        }
    }
}
