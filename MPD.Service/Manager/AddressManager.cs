using MPD.Repository;

namespace MPD.Service.Manager
{
    public class AddressManager : IAddress
    {
        private readonly IUnitOfWork _unitOfWork;
        public AddressManager(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void GetAddress()
        {
            /*
             * var address = _unitOfWork.AddressReporsitory.GetAll();
             */
        }
    }
}
