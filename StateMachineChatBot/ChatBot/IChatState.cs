using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace ChatBot
{
    public interface IChatState
    {
        Task<IChatState> HandleActivity(Update update);
    }
    
    
    public class HelloState : IChatState
    {
        private readonly IServiceProvider _provider;
        private readonly TelegramBotClient _telegram;

        public HelloState(IServiceProvider provider, TelegramBotClient telegram)
        {
            _provider = provider;
            _telegram = telegram;
        }
        
        public async Task<IChatState> HandleActivity(Update update)
        {
            await _telegram.SendTextMessageAsync(update.Message.Chat.Id, "Hello!");
            await _telegram.SendTextMessageAsync(update.Message.Chat.Id, "Жду от тебя слово");
            

            return _provider.GetRequiredService<WaitWordState>();
        }
    }
    
    public class WaitWordState : IChatState
    {
        private readonly IServiceProvider _provider;
        private readonly TelegramBotClient _telegram;
        
        public WaitWordState(IServiceProvider provider, TelegramBotClient telegram)
        {
            _provider = provider;
            _telegram = telegram;
        }
        
        public async Task<IChatState> HandleActivity(Update update)
        {
            var word = update.Message.Text;
            //save word to db
            await _telegram.SendTextMessageAsync(update.Message.Chat.Id, "Спасибо!");
            await _telegram.SendTextMessageAsync(update.Message.Chat.Id, "Пока!");


            return _provider.GetRequiredService<HelloState>();
        }
    }
}