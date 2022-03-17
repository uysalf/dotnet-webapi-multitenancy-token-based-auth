using System;
using System.Collections.Generic;

namespace Entity.ModelsDtos
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public bool IsSuccessful { get; private set; }
        public List<String> Errors { get; private set; } = new List<string>();

        public static Response<T> Success(T data , int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode, IsSuccessful = true };
        }

        public static Response<T> Fail(int statusCode, List<string> errors)
        {
            return new Response<T> { StatusCode= statusCode, IsSuccessful=false, Errors= errors };
        }
    }
}
