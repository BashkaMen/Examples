using System;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace ChatBot
{
    // register as singleton
    public class BotProcessor
    {
        private IChatState _currentState;

        public BotProcessor(IChatState currentState)
        {
            _currentState = currentState;
        }


        public async Task Handle(Update update)
        {
            try
            {
                _currentState = await _currentState.HandleActivity(update);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERROR - чини");
            }
        }
    }
}