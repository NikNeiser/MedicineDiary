using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDiary.Models.Enums
{
    public enum BotComandsEnum
    {
        /// <summary>
        /// выводит инфо о работе бота
        /// </summary>
        start,

        /// <summary>
        /// изменение часового пояса чата
        /// </summary>
        changeTime,

        /// <summary>
        /// изменение языка чата
        /// </summary>
        changeLanguage,

        /// <summary>
        /// отобразить все активные медикаменты
        /// </summary>
        viewAllMedicine,

        /// <summary>
        /// отобразить все активные медикаменты с нумерацией, число в ответ удаляет выбранныё медикамент 
        /// </summary>
        deleteMedicine

    }
}
