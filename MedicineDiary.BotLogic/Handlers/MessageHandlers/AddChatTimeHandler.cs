using MedicineDiary.BotLogic.Abstractions;
using MedicineDiary.Data.Abstraction;
using MedicineDiary.Models.Dto.Input;
using MedicineDiary.Models.Dto.Output;
using MedicineDiary.Models.Enums;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;


[assembly: InternalsVisibleTo("MedicineDiary.Tests")]
namespace MedicineDiary.BotLogic.Handlers.MessageHandlers
{
    internal class AddChatTimeHandler : HandlerBase, IHandler
    {
        public async Task<HandlerOutput> HandleAsync(HandlerInput input)
        {
            var output = new HandlerOutput();
            var culture = input.Language == LanguageEnum.ru.ToString() ?
                CultureInfo.CurrentCulture :
                new CultureInfo(input.Language);

            try
            {
                var deviation = GetUtcDeviation(ParseTime(input.Message));

                await _repository.SetChatTimeDelta(input.ChatId, deviation);

                output.Message = string.Format(
                    Resources.Resource.ResourceManager.GetString("TimeSet_Success", culture),
                    $"{deviation.Hours}:{Math.Abs(deviation.Minutes)}");
            }
            catch (FormatException ex)
            {
                output.Message = Resources.Resource.ResourceManager.GetString(ex.Message, culture);

            }
            catch (Exception ex)
            {
                output.Message = $"Произошла ошибка: {ex.Message}";
            }

            return output;
        }

        public static TimeSpan ParseTime(string input)
        {
            // Приводим строку к формату ЧЧММ 
            input = Regex.Replace(input, @"[^0-9]+", "");

            // Проверяем, что строка соответствует формату ЧЧММ
            if (string.IsNullOrEmpty(input) || input.Length != 4)
            {
                throw new FormatException("TimeSet_WrongTimeFormat");
            }

            int hours = int.Parse(input.Substring(0, 2));
            int minutes = int.Parse(input.Substring(2, 2));

            // Проверяем, что часы и минуты находятся в допустимом диапазоне
            if (hours < 0 || hours > 23 || minutes < 0 || minutes > 59)
            {
                throw new FormatException("TimeSet_WrongTimeRange");
            }

            return new TimeSpan(hours, minutes, 0);
        }

        public static TimeSpan GetUtcDeviation(TimeSpan clientTime)
        {
            var deviation = clientTime - DateTime.UtcNow.TimeOfDay;

            var hours = deviation.Hours;
            var minutes = deviation.Minutes;
            int minutesRounding = 15;

            if ( hours > 14) hours -= 24;
            if ( hours < -12) hours += 24;

            if (Math.Abs(minutes) % minutesRounding > minutesRounding/2)
            {
                minutes += minutes > 0 ? minutesRounding - minutes % minutesRounding : -minutesRounding - minutes % minutesRounding;
            }
            else
            {
                minutes -= minutes % minutesRounding;
            }            

            return new TimeSpan(hours, minutes, 0);
        }

        public AddChatTimeHandler(IDiaryRepository repository) : base(repository) { }
    }
}
