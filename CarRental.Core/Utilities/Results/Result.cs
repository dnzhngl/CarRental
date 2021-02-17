using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        // Result classı newlnediği zaman parametre olarak success ve message bilgileri girilir.
        public Result(bool success, string message) : this (success)// buradaki success'i this(bu classtaki yani Result classında) ki tek paramtereli olanı çalıştır ona success'i gönder.
        {
            Message = message;
        }
        public Result(bool success) // Constructor overloading
        {
            Success = success;
        }

        public bool Success { get; }    // Getter readonly'dir. Getter'lar constructorda set edilebilir.
        public string Message { get; }
        public int Count { get; set; }
    }
}
