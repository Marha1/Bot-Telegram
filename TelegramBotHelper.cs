using Microsoft.AspNetCore.Mvc;
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

        private static List<long> Id = new List<long>();
        Telegram.Bot.TelegramBotClient _client;
        public TelegramBotHelper(string token)
        {
            this._token = token;
        }
        internal  void GetUpdates()
        {
                _client = new Telegram.Bot.TelegramBotClient(_token);
                var updates = _client.GetUpdatesAsync().Result;
            foreach ( var item in updates)
            {
                Id.Add(item.Message.Chat.Id);

            }
            var results = Id.GroupBy(x => ((ulong)x)).Select(x => x.First()).ToList();
            if (updates != null)
             {
                    
                    
                        foreach (var update in results)
                        {
                            Thread.Sleep(2000);
                            try
                            {
                                
                                var imagePath = Path.Combine(Environment.CurrentDirectory,"1.png");
                                using (var stream = File.OpenRead(imagePath))
                                    _client.SendPhotoAsync(update, new Telegram.Bot.Types.InputFileStream(stream));
                                var text = $"С  днем рождения {Name},Успехов радости веселия Вам исполнилось {Age}";
                                _client.SendTextMessageAsync(update, text);
                            }
                            catch 
                            {

                                    Console.WriteLine("Ошибка отправки сообщений");
                            }
                           

                        }

                
            }
                

            
        }
        public void GetName(string name, int Age)
        {
            this.Name = name;
            this.Age = Age;

        }

    }
}