namespace GestionZapatillas.DTOs.Common
{
   
    public class Result
    {
        public bool IsSuccess { get; protected set; }
        public bool IsFailure => !IsSuccess;
        public bool IsConcurrencyConflict { get; protected set; }
        public List<string> Errors { get; protected set; } = new();

        public string FirstError => Errors.Count > 0 ? Errors[0] : string.Empty;

        public static Result Ok() => new() { IsSuccess = true };

        public static Result Fail(string error) =>
            new() { IsSuccess = false, Errors = new List<string> { error } };

        public static Result Fail(IEnumerable<string> errors) =>
            new() { IsSuccess = false, Errors = errors.ToList() };

        public static Result Concurrency(string error) =>
            new() { IsSuccess = false, IsConcurrencyConflict = true, Errors = new List<string> { error } };

        public static Result<T> Ok<T>(T value) =>
            new() { IsSuccess = true, Value = value };

        public static Result<T> Fail<T>(string error) =>
            new() { IsSuccess = false, Errors = new List<string> { error } };

        public static Result<T> Fail<T>(IEnumerable<string> errors) =>
            new() { IsSuccess = false, Errors = errors.ToList() };
    }

  
    public class Result<T> : Result
    {
        public T? Value { get; set; }
    }
}
