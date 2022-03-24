using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GMIS.Entity.Ground_water
{
    [Table("DOI_GroundWaterInfo")]
    public class GroundWaterInformation : FullAuditedEntity<int>
    {
        public string TubewellNo { get; set; }

        //TubeWell Information
        public string Location { get; set; }

        public string LatitudeDegree { get; set; }
        public string LatitudeMin { get; set; }
        public string LatitudeSecond { get; set; }

        public string LongitudeDegree { get; set; }
        public string LongitudeMin { get; set; }
        public string LongitudeSecond { get; set; }

        public string Elevation { get; set; }
        public string TubewellType { get; set; }
        public decimal TubewellHousingPipeSize { get; set; }
        public decimal TubewellScreenAndCastingPipeSize { get; set; }
        public decimal StaticWaterLevel{ get; set; }

        public string AquiferMaterail { get; set; }
        public decimal TotalDrillDepth { get; set; }
        public decimal HousingLength { get; set; }
        public decimal ScreenLength { get; set; }
        public string TypeOfScreen { get; set; }
        public decimal PumpingDischarge { get; set; }
        public decimal Drawdown { get; set; }
        public decimal AquiferStorageCoefficient { get; set; }
        public decimal Aquifertransmissivity { get; set; }

        //Pump Information
        public string BrandOfPump { get; set; }
        public decimal Power { get; set; }
        public decimal Head { get; set; }
        public decimal PumpDischarge{ get; set; }
        public decimal EfficienyOfMoter{ get; set; }
        public decimal EfficienyOfPump { get; set; }
        public decimal PumpLoweringDepth { get; set; }
        public decimal ColumnPipeSize { get; set; }
        public string ColumnType { get; set; }

        //Pump House Information
        public string SizeOfPumpHouse{ get; set; }
        public decimal HeightOfOverheadTank{ get; set; }
        public decimal VolumeOverheadTank { get; set; }

        //Distribution System
        public string TypeOfDistributionSystem { get; set; }
        public decimal NoOfOutlets { get; set; }
        public decimal? LengthOfOpenChannel { get; set; }
        public decimal? SizeOfAlphaValve { get; set; }
        public string PipeMaterial { get; set; }
        public decimal? LengthOfPipe { get; set; }
        public decimal? NoOfSurgeRaiser { get; set; }

        //Electrification
        public decimal LengthOf11KvHtTransLine { get; set; }
        public decimal Lengthof440VLtTransLine { get; set; }
        public decimal NumberOfPoles { get; set; }
        public decimal TransformerCapacity { get; set; }
        public decimal ControlPanel { get; set; }
        public decimal VoltageStabilizer { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public virtual Project Project { get; set; }

        public string TubeWellName { get; set; }
        public decimal CommandArea { get; set; }
        public string PumpInfoColumnTypeOther { get; set; }
        public int Numberofpolesheading_HT_LT { get; set; }
        public string TransformerBrand { get; set; }
    }
}
