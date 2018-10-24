using System.Collections.Generic;
using KomodoHires.Models.Contract;

namespace KomodoHires.Contracts
{
    public interface IContractService
    {
        bool CreateContract(ContractCreate model);
        bool DeleteContract(int contractID);
        ContractDetail GetContractById(int contractId);
        IEnumerable<ContractListItem> GetContracts();
        bool UpdateContract(ContractEdit model);
    }
}