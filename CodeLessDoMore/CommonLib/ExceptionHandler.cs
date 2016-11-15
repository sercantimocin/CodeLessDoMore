using System;

namespace CommonLib
{
    /// <summary>
    /// The custom result.
    /// </summary>
    /// <typeparam name="T">
    /// T
    /// </typeparam>
    public class CustomResult<T>
    {
        /// <summary>
        /// Gets or sets the result object.
        /// </summary>
        public T ResultObject { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether is successful.
        /// </summary>
        public bool IsSuccessful { get; set; }

        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        public string ErrorMessage { get; set; }
    }

    /// <summary>
    /// The exception handler.
    /// </summary>
    public static class ExceptionHandler
    {
        /// <summary>
        /// The execute function with handler.
        /// </summary>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <typeparam name="T">
        /// T
        /// </typeparam>
        /// <returns>
        /// The <see cref="CustomResult"/>.
        /// </returns>
        public static CustomResult<T> ExecuteFunction<T>(Func<T> function)
        {
            CustomResult<T> result = new CustomResult<T>();

            try
            {
                var genericResult = function();
                result.ResultObject = genericResult;
                result.IsSuccessful = true;
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = ex.InnerException?.Message ?? ex.Message;
            }

            return result;
        }

        /// <summary>
        /// The execute function with handler.
        /// </summary>
        /// <param name="function">
        /// The function.
        /// </param>
        /// <param name="errorMessage">
        /// The error message.
        /// </param>
        /// <typeparam name="T">
        /// T
        /// </typeparam>
        /// <returns>
        /// The <see cref="CustomResult"/>.
        /// </returns>
        public static CustomResult<T> ExecuteFunction<T>(Func<T> function, ref string errorMessage)
        {
            CustomResult<T> result = new CustomResult<T>();

            try
            {
                var genericResult = function();

                if (!string.IsNullOrWhiteSpace(errorMessage))
                {
                    result.IsSuccessful = false;
                    result.ErrorMessage = errorMessage;
                }
                else
                {
                    result.ResultObject = genericResult;
                    result.IsSuccessful = true;
                }
            }
            catch (Exception ex)
            {
                result.IsSuccessful = false;
                result.ErrorMessage = ex.InnerException?.Message ?? ex.Message;
            }

            return result;
        }

    }
}
