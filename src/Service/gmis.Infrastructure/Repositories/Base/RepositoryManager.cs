using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.Configuration;
using gmis.Application.Contracts.Persistence.Base;
using gmis.Infrastructure.Persistence.Context;
using gmis.Application.Contracts.Persistence;
using gmis.Infrastructure.Repositories.LOF;

namespace gmis.Infrastructure.Repositories.Base
{
    public class RepositoryManager : IRepositoryManager
    {
        private RepositoryContext _repositoryContext;
        private readonly IConfiguration _configuration;
        public RepositoryManager(RepositoryContext repositoryContext, IConfiguration configuration)
        {
            _repositoryContext = repositoryContext;
            _configuration = configuration;
        }
        public Task SaveAsync() => _repositoryContext.SaveChangesAsync();

        public IDbContextTransaction BeginTran()
        {
            return _repositoryContext.Database.BeginTransaction();
        }
        #region Line Of Business
        public ILineOfBusinessRepository LineOfBusinessRepository => new LineOfBusinessRepository(_configuration, _repositoryContext);
        #endregion
        //public IUserDetailsRepository userDetailsRepository => new UserDetailsRepository(_configuration, _repositoryContext);

        //#region Hotel Config
        //public IHotelDetailRepository hotelDetailsRepository => new HotelDetailRepository(_configuration, _repositoryContext);
        //public IHotelAmenitiesRepository hotelAmenitiesRepository => new HotelAmenitiesRepository(_configuration, _repositoryContext);
        //public IHotelContactPersonRepository hotelContactPersonRepository => new HotelContactPersonRepository(_configuration, _repositoryContext);
        //public IHotelAddressRepository hotelAddressRepository => new HotelAddressRepository(_configuration, _repositoryContext);
        //public IHotelFacilitiesRepository hotelFacilitiesRepository => new HotelFacilitiesRepository(_configuration, _repositoryContext);
        //public IHotelConfigurationRepository hotelConfigurationRepository => new HotelConfigurationRepository(_configuration, _repositoryContext);
        //public IHotelBeddingTypeRepository hotelBeddingTypeRepository => new HotelBeddingTypeRepository(_configuration, _repositoryContext);
        //public IHotelBeddingRepository hotelBeddingRepository => new HotelBeddingRepository(_configuration, _repositoryContext);
        //#endregion

        //#region Hotel Room Config
        //public IHotelRoomAmenitiesRepository hotelRoomAmenitiesRepository => new HotelRoomAmenitiesRepository(_configuration, _repositoryContext);
        //public IInventoryRepository inventoryRepository => new InventoryRepository(_configuration, _repositoryContext);
        //public IHotelRoomTypeRepository hotelRoomTypeRepository => new HotelRoomTypeRepository(_configuration, _repositoryContext);
        //public IHotelRoomFacilitiesRepository hotelRoomFacilitiesRepository => new HotelRoomFacilitiesRepository(_configuration, _repositoryContext);
        //public IInclusionsRepository inclusionsRepository => new InclusionsRepository(_configuration, _repositoryContext);
        //#endregion

        //#region Room rates
        ////public IRatePlanRepository ratePlanRepository => new RatePlanRepository(_configuration, _repositoryContext);
        //public IRateRepository rateRepository => new RateRepository(_configuration, _repositoryContext);
        //public IChargeablesRepository chargeablesRepository => new ChargeablesRepository(_configuration, _repositoryContext);
        //#endregion

        //#region Media
        //public IMediaRepository mediaRepository => new MediaRepository(_configuration, _repositoryContext);
        //#endregion

        //#region Master Config

        //public IRoomTypeRepository roomTypeRepository => new RoomTypeRepository(_configuration, _repositoryContext);
        //public IMasterAmenitiesRepository masterAmenitiesRepository => new MasterAmenitiesRepository(_configuration, _repositoryContext);
        //public IRoomAmenitiesRepository roomAmenitiesRepository => new RoomAmenitiesRepository(_configuration, _repositoryContext);
        //public IPropertyRepository propertyRepository => new PropertyRepository(_configuration, _repositoryContext);
        //public IPhotocategoryRepository photocategoryRepository => new PhotocategoryRepository(_configuration, _repositoryContext);
        //public IFacilitiesRepository facilitiesRepository => new FacilitiesRepository(_configuration, _repositoryContext);
        //public IBoardBasisRepository boardBasisRepository => new BoardBasisRepository(_configuration, _repositoryContext);
        //public IBeddingTypeRepository beddingTypeRepository => new BeddingTypeRepository(_configuration, _repositoryContext);
        //public IClientTypeRepository clientTypeRepository => new ClientTypeRepository(_configuration, _repositoryContext);
        //public IRoomFacilitiesRepository roomFacilitiesRepository => new RoomFacilitiesRepository(_configuration, _repositoryContext);
        //public IRoomAttributeRepository roomAttributeRepository => new RoomAttributeRepository(_configuration, _repositoryContext);
        //#endregion

        //#region Region   
        //public IRegionRepository regionRepository => new RegionRepository(_configuration, _repositoryContext);


        //#endregion


    }
}
