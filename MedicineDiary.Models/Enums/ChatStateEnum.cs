namespace MedicineDiary.Models.Enums
{
    /// <summary>
    /// Перечисление состояний чатов.
    /// </summary>
    public enum ChatStateEnum 
    {
        /// <summary>
        /// Нет данных о часовом поясе
        /// </summary>
        NoRegistred = 0,

        /// <summary>
        /// Ожидание времени чата, для расчёт отклонения от сервера
        /// </summary>
        AddChatTime = 1,

        /// <summary>
        /// Готов принимать данные
        /// </summary>
        Registred = 2,

        /// <summary>
        /// Ожидание новых данных
        /// </summary>
        AddNewMedicine = 3,

        /// <summary>
        /// Ожидание частоты приёма
        /// </summary>
        AddFrequency = 4,

        /// <summary>
        /// Ожидание времени приёма
        /// </summary>
        AddMedicineTime = 5,

        /// <summary>
        /// Ожидание кол-ва дней приёма
        /// </summary>
        AddDays = 6,

        /// <summary>
        /// Ожидание лекарства для удаления
        /// </summary>
        DeleteMedicine = 7,

        /// <summary>
        /// Принято ли последнее лекарство
        /// </summary>
        MedicineTaken = 8,

        /// <summary>
        /// Ожидание изменения языка чата
        /// </summary>
        ChangeLanguage = 9

    }
}
