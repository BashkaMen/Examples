using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ChatBot
{
    public class BotController
    {
        private readonly BotProcessor _botProcessor;

        public BotController(BotProcessor botProcessor)
        {
            _botProcessor = botProcessor;
        }
        
        //[HttpPost("/webhook")]
        public async Task HandleChatActivity(/*[FromBody]*/Update update)
        {
            await _botProcessor.Handle(update);
        }
    }
}