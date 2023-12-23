using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using WebApplication12.Models;

namespace WebApplication12
{
    internal class TelegramBotHelper
    {
        private string _token;

        string Name;
        int Age;

        Telegram.Bot.TelegramBotClient _client;
        public TelegramBotHelper(string token)
        {
            this._token = token;
        }
        public TelegramBotHelper()
        {

        }

        internal async void GetUpdates()
        {
            
            
                _client = new Telegram.Bot.TelegramBotClient(_token);
                while (true)
                {
                    try
                    {
                        int offset = 0;
                        var updates = _client.GetUpdatesAsync().Result; ;//получение инфы что написали
                        foreach (var update in updates)
                        {

                            
                            processUpdate(update);
                            Thread.Sleep(1000);
                            offset = update.Id + 1;
                            break;

                        }
                        break;

                    }
                    catch (Exception)
                    {

                        throw;
                    }
                }

            
        }
        public void GetName(string name, int Age)
        {
            this.Name = name;
            this.Age = Age;

        }

        internal void processUpdate(Telegram.Bot.Types.Update update)
        {
            string imagePath = Path.Combine(Environment.CurrentDirectory,"1.png");
            using (var stream = File.OpenRead(imagePath))
                _client.SendPhotoAsync(update.Message.Chat.Id, new Telegram.Bot.Types.InputFileStream(stream));

            var text = $"С  днем рождения {Name},Успехов радости веселия Вам исполнилось {Age}";
            _client.SendTextMessageAsync(update.Message.Chat.Id, text);
            imagePath = null;

        }





    }
}