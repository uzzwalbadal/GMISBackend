using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.Ground_waters.Dto;
using GMIS.Entity.Ground_water;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GMIS.DOI.Ground_waters
{
    [AbpAuthorize]
    public class GroundWaterAppService : AsyncCrudAppService<GroundWaterInformation, Dto_GroundWaterInformation, int, PagedResultRequestDto, Dto_GroundWaterInformation, Dto_GroundWaterInformation>
    {
        private readonly IRepository<GroundWaterInformation, int> _repository;

        public GroundWaterAppService(
            IRepository<GroundWaterInformation, int> repository
            ) : base(repository)
        {
            _repository = repository;
        }

        public List<Dto_GroundWaterInformation> GetGroundWaterInfoListByProjectId(Guid projectId)
        {
            //var result = _repository.GetAll()
            //    .Where(x => x.IsDeleted == false && x.ProjectId == projectId)
            //    .Select(info => new Dto_GroundWaterInformation
            //    {
            //        AquiferMaterail = info.AquiferMaterail,
            //        AquiferStorageCoefficient = info.AquiferStorageCoefficient,
            //        Aquifertransmissivity = info.Aquifertransmissivity,
            //        BrandOfPump = info.BrandOfPump,
            //        ColumnPipeSize = info.ColumnPipeSize,
            //        ColumnType = info.ColumnType,
            //        ControlPanel = info.ControlPanel,
            //        Drawdown = info.Drawdown,
            //        EfficienyOfMoter = info.EfficienyOfMoter,
            //        EfficienyOfPump = info.EfficienyOfPump,
            //        Elevation = info.Elevation,
            //        Head = info.Head,
            //        HeightOfOverheadTank = info.HeightOfOverheadTank,
            //        HousingLength = info.HousingLength,
            //        Id = info.Id,
            //        Laltitude = info.Laltitude,
            //        LengthOf11KvHtTransLine = info.LengthOf11KvHtTransLine,
            //        Lengthof440VLtTransLine = info.Lengthof440VLtTransLine,
            //        LengthOfOpenChannel = info.LengthOfOpenChannel,
            //        LengthOfPipe = info.LengthOfPipe,
            //        Location = info.Location,
            //        Longitude = info.Longitude,
            //        NoOfOutlets = info.NoOfOutlets,
            //        NoOfSurgeRaiser = info.NoOfSurgeRaiser,
            //        NumberOfPoles = info.NumberOfPoles,
            //        PipeMaterial = info.PipeMaterial,
            //        Power = info.Power,
            //        ProjectId = info.ProjectId,
            //        PumpDischarge = info.PumpDischarge,
            //        PumpingDischarge = info.PumpingDischarge,
            //        PumpLoweringDepth = info.PumpLoweringDepth,
            //        ScreenLength = info.ScreenLength,
            //        SizeOfAlphaValve = info.SizeOfAlphaValve,
            //        SizeOfPumpHouse = info.SizeOfPumpHouse,
            //        StaticWaterLevel = info.StaticWaterLevel,
            //        TotalDrillDepth = info.TotalDrillDepth,
            //        TransformerCapacity = info.TransformerCapacity,
            //        TubewellHousingPipeSize = info.TubewellHousingPipeSize,
            //        TubewellNo = info.TubewellNo,
            //        TubewellScreenAndCastingPipeSize = info.TubewellScreenAndCastingPipeSize,
            //        TubewellType = info.TubewellType,
            //        TypeOfDistributionSystem = info.TypeOfDistributionSystem,
            //        TypeOfScreen = info.TypeOfScreen,
            //        VoltageStabilizer = info.VoltageStabilizer,
            //        VolumeOverheadTank = info.VolumeOverheadTank
            //    });

            var results = _repository.GetAll()
                .Where(x => x.IsDeleted == false && x.ProjectId == projectId);
            var result = ObjectMapper.Map<List<Dto_GroundWaterInformation>>(results.ToList());
            return result;
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_GroundWaterInformation> Create(Dto_GroundWaterInformation input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.TubewellNo == input.TubewellNo);
            if (response.Result != null)
            {
                throw new UserFriendlyException("TubeWell No: " + input.TubewellNo + " data already inserted");
            }
            if(string.Compare(input.TypeOfDistributionSystem,"Buried Pipe", true) == 0){
                input.LengthOfOpenChannel = 0;
                input.SizeOfAlphaValve = 0;
                input.PipeMaterial = "";
                input.LengthOfPipe = 0;
                input.NoOfSurgeRaiser = 0;
            }
            else
            {
                if (string.IsNullOrEmpty(input.PipeMaterial))
                {
                    throw new UserFriendlyException("Pipe Materail Is not selected");
                }
                if (input.LengthOfOpenChannel < 0 || input.SizeOfAlphaValve < 0 || input.LengthOfPipe<0 || input.NoOfSurgeRaiser < 0)
                {
                    throw new UserFriendlyException("Error Materail Is not selected");
                }
            }
            if (string.Compare(input.ColumnType, "Others", true) == 0)
            {
                if (string.IsNullOrEmpty(input.PumpInfoColumnTypeOther))
                {
                    throw new UserFriendlyException("Pump Info Column Type Other Name Is required");
                }
            }
            else
            {
                input.PumpInfoColumnTypeOther = "";
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_GroundWaterInformation> Update(Dto_GroundWaterInformation input)
        {
            var response = _repository.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.TubewellNo == input.TubewellNo && x.Id != input.Id);
            if (response.Result != null)
            {
                throw new UserFriendlyException("TubeWell No: " + input.TubewellNo + " data already inserted");
            }
            if (string.Compare(input.TypeOfDistributionSystem, "Buried Pipe", true) == 0)
            {
                input.LengthOfOpenChannel = 0;
                input.SizeOfAlphaValve = 0;
                input.PipeMaterial = "";
                input.LengthOfPipe = 0;
                input.NoOfSurgeRaiser = 0;
            }
            else
            {
                if (string.IsNullOrEmpty(input.PipeMaterial))
                {
                    throw new UserFriendlyException("Pipe Materail Is not selected");
                }
                if (input.LengthOfOpenChannel < 0 || input.SizeOfAlphaValve < 0 || input.LengthOfPipe < 0 || input.NoOfSurgeRaiser < 0)
                {
                    throw new UserFriendlyException("Error Materail Is not selected");
                }
            }
            if (string.Compare(input.ColumnType, "Others", true) == 0)
            {
                if (string.IsNullOrEmpty(input.PumpInfoColumnTypeOther))
                {
                    throw new UserFriendlyException("Pump Info Column Type Other Name Is required");
                }
            }
            else
            {
                input.PumpInfoColumnTypeOther = "";
            }
            return base.Update(input);
        }

        [AbpAuthorize("Pages.Tenants")]
        public override Task Delete(EntityDto<int> input)
        {
            return base.Delete(input);
        }
    }
}
