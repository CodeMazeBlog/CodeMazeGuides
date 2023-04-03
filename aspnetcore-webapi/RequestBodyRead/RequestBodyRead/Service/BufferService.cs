using System;
using System.Buffers;
using System.IO.Pipelines;
using System.Text;
using Newtonsoft.Json;
using RequestBodyRead.Service.Contracts;
using RequestBodyRead.Shared.DataTransferObjects;

namespace RequestBodyRead.Service
{
	public class BufferService : IBufferService
	{
		public async Task<List<UserForCreationAndUpdateDto>> ReadUserModelAsync(PipeReader reader)
		{
            var sb = new StringBuilder();

			while (true)
			{
                var rawReqBody = await reader.ReadAsync();
				var buffer = rawReqBody.Buffer;
                var line = ReadItems(buffer);
                sb.Append(line);
                reader.AdvanceTo(buffer.Start, buffer.End);

                if (rawReqBody.IsCompleted)
                    break;
            }

            await reader.CompleteAsync();

            var body = sb.ToString();
			var result = JsonConvert.DeserializeObject<List<UserForCreationAndUpdateDto>>(body);
			return result;
		}

        private string ReadItems(in ReadOnlySequence<byte> sequence)
        {
            var decoder = Encoding.UTF8.GetDecoder();
            var sb = new StringBuilder();
            var processed = 0L;
            var length = sequence.Length;

            foreach (var b in sequence)
            {
                processed += b.Length;
                var isComplete = processed == length;
                var span = b.Span;
                var charCount = decoder.GetCharCount(span, isComplete);
                Span<char> buffer = stackalloc char[charCount];
                decoder.GetChars(span, buffer, isComplete);
                sb.Append(buffer);
            }

            var res = sb.ToString();
            return res;
        }
    }
}

