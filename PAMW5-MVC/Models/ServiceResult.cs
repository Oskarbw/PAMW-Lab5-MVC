namespace PAMW5_MVC.Models
{
    public class ServiceResult<T>
    {
        public T? Data { get; set; }

        public bool IsSuccessful { get; set; }

        public string? ErrorMessage { get; set; }

    }
}
