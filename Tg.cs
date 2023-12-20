using System;
namespace WebApplication12
{
    public class Tg
    {
       

        public void Bot()
        {
            try
            {
                TelegramBotHelper telegram=new TelegramBotHelper(token:"6860178002:AAEnaBeLfhvsehNKVv9xDbrPcVZyfkwmsI0");
                telegram.GetUpdates();



            }
            catch (Exception)
            {

                throw;
            }
        }
		
	}

  
}
