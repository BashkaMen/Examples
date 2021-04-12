using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;

namespace ChatBot
{
    public static class Configure
    {
        public static void AddChatBot(this IServiceCollection services)
        {
            services.AddSingleton(new TelegramBotClient("...."));


            services.AddSingleton<BotProcessor>();
            
            services.AddTransient<HelloState>();
            services.AddTransient<WaitWordState>();
            
            services.AddTransient<IChatState, HelloState>(); // start state
        }
    }
}