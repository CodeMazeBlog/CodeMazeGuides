using Banking.Domain;

namespace Banking.Application;

public interface ITransferRepository
{
    void Add(Transfer transfer);
}
