using Microsoft.EntityFrameworkCore.Storage;

namespace gmis.Application.Contracts.Persistence.Base
{
    public interface IRepositoryManager
    {
        Task SaveAsync();
        IDbContextTransaction BeginTran();
        //IUserDetailsRepository userDetailsRepository { get; }

        #region Line Of Business
        ILineOfBusinessRepository LineOfBusinessRepository { get; }
        #endregion

        //#region Hotel Configuration
        //IHotelDetailRepository hotelDetailsRepository { get; }
        //IHotelAmenitiesRepository hotelAmenitiesRepository { get; }
        //IHotelContactPersonRepository hotelContactPersonRepository { get; }
        //IHotelAddressRepository hotelAddressRepository { get; }
        //IHotelFacilitiesRepository hotelFacilitiesRepository { get; }
        //IHotelConfigurationRepository hotelConfigurationRepository { get; }
        //IHotelBeddingTypeRepository hotelBeddingTypeRepository { get; }
        //IHotelBeddingRepository hotelBeddingRepository { get; }
        //#endregion

        //#region Room Configuration      
        //IHotelRoomAmenitiesRepository hotelRoomAmenitiesRepository { get; }
        //IInventoryRepository inventoryRepository { get; }
        //IHotelRoomTypeRepository hotelRoomTypeRepository { get; }
        //IHotelRoomFacilitiesRepository hotelRoomFacilitiesRepository { get; }
        //IInclusionsRepository inclusionsRepository { get; }
        //#endregion

        //#region Room rates
        //IRatePlanRepository ratePlanRepository { get; }
        //IRateRepository rateRepository { get; }
        //IChargeablesRepository chargeablesRepository { get; }
        //#endregion

        //#region Media
        //IMediaRepository mediaRepository { get; }
        //#endregion

        //#region Master Configuration
        //IRoomTypeRepository roomTypeRepository { get; }
        //IMasterAmenitiesRepository masterAmenitiesRepository { get; }
        //IPropertyRepository propertyRepository { get; }
        //IRoomAmenitiesRepository roomAmenitiesRepository { get; }
        //IPhotocategoryRepository photocategoryRepository { get; }
        //IFacilitiesRepository facilitiesRepository { get; }
        //IBoardBasisRepository boardBasisRepository { get; }
        //IBeddingTypeRepository beddingTypeRepository { get; }
        //IClientTypeRepository clientTypeRepository { get; }
        //IRoomFacilitiesRepository roomFacilitiesRepository { get; }
        //IRoomAttributeRepository roomAttributeRepository { get; }
        //#endregion

        //#region Region
        //IRegionRepository regionRepository { get; }
        //#endregion
    }
}
