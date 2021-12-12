﻿using System.Text.Json.Serialization;

namespace Shared.Dtos
{
    public class Response<T> where T : class
    {
        public T Data { get; private set; }
        public int StatusCode { get; private set; }
        public ErrorDto Error { get; private set; }
        [JsonIgnore] public bool IsSuccessful { get; private set; }

        public static Response<T> Success(int statusCode) => new() { StatusCode = statusCode, IsSuccessful = true };
        public static Response<T> Success(T data, int statusCode) => new() { Data = data, StatusCode = statusCode, IsSuccessful = true };

        public static Response<T> Fail(ErrorDto error, int statusCode) => new() { Error = error, StatusCode = statusCode, IsSuccessful = false };
        public static Response<T> Fail(string errorMessage, int statusCode, bool isShow)
        {
            var errorDto = new ErrorDto(errorMessage, isShow);
            return new() { Error = errorDto, StatusCode = statusCode, IsSuccessful = false };
        }
    }
}
