﻿using FreecraftCore.Serializer.KnownTypes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;


namespace FreecraftCore.Serializer.Tests
{
	[TestFixture]
	public class ByteSerializerTests
	{
		[Test]
		[TestCase(0)]
		[TestCase(255)]
		[TestCase(1)]
		public void Test_Byte_Serializer_Doesnt_Throw_On_Serialize(byte data)
		{
			ITypeSerializerStrategy strategy = new GenericTypePrimitiveSharedBufferSerializerStrategy<byte>();

			Assert.DoesNotThrow(() => strategy.Write(data, new TestStorageWriterMock()));
		}

		[Test]
		[TestCase(0)]
		[TestCase(255)]
		[TestCase(1)]
		public void Test_Byte_Serializer_Writes_Bytes_Into_WriterStream(byte data)
		{
			//arrange
			ITypeSerializerStrategy strategy = new GenericTypePrimitiveSharedBufferSerializerStrategy<byte>();
			TestStorageWriterMock writer = new TestStorageWriterMock();

			//act
			strategy.Write(data, writer);

			//assert
			Assert.False(writer.WriterStream.Length == 0);
		}

		[Test]
		[TestCase(0)]
		[TestCase(255)]
		[TestCase(1)]
		public void Test_Byte_Serializer_Writes_And_Reads_Same_Byte(byte data)
		{
			//arrange
			ITypeSerializerStrategy strategy = new GenericTypePrimitiveSharedBufferSerializerStrategy<byte>();
			TestStorageWriterMock writer = new TestStorageWriterMock();
			TestStorageReaderMock reader = new TestStorageReaderMock(writer.WriterStream);

			//act
			strategy.Write(data, writer);
			writer.WriterStream.Position = 0;
			byte b = reader.ReadByte();

			//assert
			Assert.AreEqual(data, b);
		}

		[Test]
		[TestCase((sbyte)0)]
		[TestCase(SByte.MaxValue)]
		[TestCase((sbyte)-50)]
		[TestCase((sbyte)50)]
		public void Test_SByte_Serializer_Writes_And_Reads_Same_Byte(sbyte data)
		{
			//arrange
			ITypeSerializerStrategy strategy = new GenericTypePrimitiveSharedBufferSerializerStrategy<sbyte>();
			TestStorageWriterMock writer = new TestStorageWriterMock();
			TestStorageReaderMock reader = new TestStorageReaderMock(writer.WriterStream);

			//act
			strategy.Write(data, writer);
			writer.WriterStream.Position = 0;

			//assert
			Assert.AreEqual(data, strategy.Read(reader));
		}

		/*[Test]
		[TestCase(0,1,2,3)]
		[TestCase(255,0,255,0)]
		[TestCase(1,1,1,1)]
		public void Test_Byte_Serializer_Writes_And_Reads_Same_ByteArray(params byte[] data)
		{
			//arrange
			ByteSerializerStrategy strategy = new ByteSerializerStrategy();
			TestStorageWriterMock writer = new TestStorageWriterMock();
			TestStorageReaderMock reader = new TestStorageReaderMock(writer.WriterStream);

			//act
			strategy.Write(data, writer);
			writer.WriterStream.Position = 0;
			byte b = reader.ReadByte();

			//assert
			Assert.AreEqual(data, b);
		}*/
	}
}
