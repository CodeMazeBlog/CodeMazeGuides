using System;
using RequestBodyRead.Shared.DataTransferObjects;
using System.IO.Pipelines;

namespace RequestBodyRead.Service.Contracts
{
	public interface IBufferService
	{
        public Task<List<UserForCreationAndUpdateDto>> ReadUserModelAsync(PipeReader reader);
    }
}

