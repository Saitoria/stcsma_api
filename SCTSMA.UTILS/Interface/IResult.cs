namespace SCTSMA.UTILS.Interface
{
    public interface IResult<T>
    {
        string message { get; set; }

        bool succeeded { get; set; }

        T data { get; set; }

        int code { get; set; }
    }
}
