﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FreecraftCore.Serializer
{
	/// <summary>
	/// Contract for a serialization service.
	/// </summary>
	public interface ISerializerService : ISerializationContractRegister, ISerializationService
	{
		/// <summary>
		/// Call to finalize the serialization service.
		/// This is required to serialize or deserialize types.
		/// </summary>
		void Compile();

		/// <summary>
		/// Indicates if the serializer is compiled.
		/// </summary>
		bool isCompiled { get; }
	}
}