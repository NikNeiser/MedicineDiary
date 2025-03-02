using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicineDiary.Models.Dto.Input
{
    public class HandlerInput
    {
        public long ChatId { get; set; }
        public string Message { get; set; }
        public string Language { get; set; }
    }
}
