using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Exceptions
{
   
		/// <summary>
		/// Custom exception to be used when throwing bad request error messages to the user.
		/// </summary>
		public class BadRequestException : Exception
		{
			/// <summary>
			/// Default Constructor BadRequestException
			/// </summary>
			public BadRequestException()
			{
			}

			/// <summary>
			/// Constructor BadRequestException
			/// </summary>
			/// <param name="message"></param>
			public BadRequestException(string message)
				: base(message)
			{
			}

			/// <summary>
			/// Constructor BadRequestException
			/// </summary>
			/// <param name="message"></param>
			/// <param name="inner"></param>
			public BadRequestException(string message, Exception inner)
				: base(message, inner)
			{
			}
		}
}
