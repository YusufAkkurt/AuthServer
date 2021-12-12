using System.Collections.Generic;

namespace Shared.Dtos
{
    public class ErrorDto
    {
        public List<string> Messages { get; } = new List<string>();
        public bool IsShow { get; }

        public ErrorDto(string error, bool isShow)
        {
            Messages.Add(error);
            IsShow = isShow;
        }

        public ErrorDto(List<string> errors, bool isShow)
        {
            Messages = errors;
            IsShow = isShow;
        }
    }
}
