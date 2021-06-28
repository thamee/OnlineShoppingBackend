using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlinePortal.Api.Exceptions
{
	/// <summary>
	/// Custom exception to be used when throwing not found specific error messages to the user.
	/// </summary>
	public class NotFoundException : Exception
	{
		/// <summary>
		/// Constructor NotFoundException
		/// </summary>
		public NotFoundException()
		{
		}

		/// <summary>
		/// Constructor NotFoundException
		/// </summary>
		/// <param name="message"></param>
		public NotFoundException(string message)
			: base(message)
		{
		}

		/// <summary>
		/// Constructor NotFoundException
		/// </summary>
		/// <param name="message"></param>
		/// <param name="inner"></param>
		public NotFoundException(string message, Exception inner)
			: base(message, inner)
		{
		}
	}
}
