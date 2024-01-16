using System.Text.Json;

 namespace Maze.Domain.ViewModels.Response
{
    public class ResponseBindingModel<T>
    {
        public bool Succeeded { get; set; } = true;
        public T? Result { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
        /// <summary>
        /// Field with the error result only if request is not succeeded (i.e., Succeeded = false)
        /// </summary>

        public bool ShouldSerializeErrorResult()
        {
            // Don't serialize the ErrorResult property if property Succeeded has true value
            return !Succeeded;
        }

        /// <summary>
        /// Field with the error result only if request is not succeeded (i.e., Succeeded = false)
        /// </summary>
        public ErrorMessageBindingModel? ErrorResult { get; set; }
    }
}
