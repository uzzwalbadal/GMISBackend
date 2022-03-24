using Abp.Application.Services;
using Abp.Application.Services.Dto;
using Abp.Authorization;
using Abp.Domain.Repositories;
using Abp.UI;
using GMIS.DOI.EngineeringInfos.HeadWorks.Dto;
using GMIS.Entity.engineering;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GMIS.DOI.EngineeringInfos.HeadWorks
{
    [AbpAuthorize]
    public class HeadWorkAppService : AsyncCrudAppService<HeadWork, Dto_HeadWork, int, PagedResultRequestDto, Dto_HeadWork, Dto_HeadWork>
    {
        private readonly IRepository<HeadWork, int> _HeadWorkRepo;

        public HeadWorkAppService(IRepository<HeadWork, int> repository) : base(repository)
        {
            _HeadWorkRepo = repository;
        }

        public async Task<Dto_HeadWork> GetHeadWorksInfoByProjectId(Guid projectId)
        {
            var riverHydrology = await _HeadWorkRepo.FirstOrDefaultAsync(x => x.IsDeleted == false && x.ProjectId == projectId);
            if (riverHydrology != null)
            {
                return ObjectMapper.Map<Dto_HeadWork>(riverHydrology);
            }
            else
            {
                return ObjectMapper.Map<Dto_HeadWork>(new Dto_HeadWork());
            }
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_HeadWork> Create(Dto_HeadWork input)
        {
            var projects = _HeadWorkRepo.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.ProjectId);
            if (projects != null)
            {
                throw new UserFriendlyException("Head Works Informtion Already Added.");
            }

            if (
                (string.Compare(input.HeadWorksType, "Barrage", true) == 0) ||
                (string.Compare(input.HeadWorksType, "Wier", true) == 0) ||
                (string.Compare(input.HeadWorksType, "BankIntake", true) == 0) ||
                (string.Compare(input.HeadWorksType, "Others", true) == 0)
                )
            {
            }
            else
            {
                throw new UserFriendlyException("HeadWork Type Not Found.");
            }

            if (string.Compare(input.HeadWorksType, "Barrage", true) == 0)
            {
                if (
                    input.BarrageTotalLength >= 0 &&
                    input.NoOfBaysOrGates >= 0 &&
                    input.LengthOfEachBayOpening >= 0 &&
                    input.CrestElevation >= 0 &&

                    input.NoOfUndersluice >= 0 &&
                    input.NoOfUndersluiceBaysOrGates >= 0 &&
                    input.UndersluiceLengthOfEachBayOpening >= 0 &&
                    input.UndersluiceCrestElevation >= 0 &&

                    input.BarrageNoOfHeadRegulators >= 0 &&
                    input.BarrageWidthHeadRegulators >= 0 &&
                    input.BarrageNoOfHeadRegulatorsBays >= 0 &&
                    input.BarrageWidthOfEachBayOpening >= 0 &&
                    input.BarrageCrestElevation >= 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type Barrage.");
                }
                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;

                input.HeadWorksTypeOther = null;
            }
            else if (string.Compare(input.HeadWorksType, "Wier", true) == 0)
            {
                if (
                    input.WeirTotalLength >= 0 &&
                    input.WeirCrestElevation >= 0 &&
                    input.WeirNoOfUndersluice >= 0 &&
                    input.WeirNoOfUndersluiceBaysOrGates >= 0 &&
                    input.WeirUndersluiceLengthOfEachBayOpening >= 0 &&
                    input.WeirUndersluiceCrestElevation >= 0 &&

                    input.WeirNoOfHeadRegulators >= 0 &&
                    input.WeirWidthHeadRegulators >= 0 &&
                    input.WeirNoOfHeadRegulatorsBays >= 0 &&
                    input.WeirWidthOfEachBayOpening >= 0 &&
                    input.WeirHeadRegulatorsCrestElevation >= 0
                    ) { }else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type Wier.");
                }

                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;

                input.HeadWorksTypeOther = null;
            }
            else if (string.Compare(input.HeadWorksType, "BankIntake", true) == 0)
            {
                if (
                   input.BankIntakeIsGated.HasValue &&
                   input.StillLevelLength >= 0 &&
                   input.SizeOfOrificeHeight >= 0 &&
                   input.SizeOfOrificeWidth >= 0)
                { }else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type BankIntake.");
                }
                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.HeadWorksTypeOther = null;
            }
            else
            {
                if (string.IsNullOrEmpty(input.HeadWorksTypeOther))
                {
                    throw new UserFriendlyException("Please Specify Details for HeadWork Type Others.");
                }
                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;
            }
            return base.Create(input);
        }

        [AbpAuthorize("Pages.Users", "Pages.DataInsert")]
        public override Task<Dto_HeadWork> Update(Dto_HeadWork input)
        {
            var projects = _HeadWorkRepo.FirstOrDefault(x => x.IsDeleted == false && x.ProjectId == input.ProjectId && x.Id == input.Id);
            if (projects == null)
            {
                throw new UserFriendlyException("Head Works Informtion Not FOund.");
            }

            if (
                (string.Compare(input.HeadWorksType, "Barrage", true) == 0) ||
                (string.Compare(input.HeadWorksType, "Wier", true) == 0) ||
                (string.Compare(input.HeadWorksType, "BankIntake", true) == 0) ||
                (string.Compare(input.HeadWorksType, "Others", true) == 0)
                )
            {
            }
            else
            {
                throw new UserFriendlyException("HeadWork Type Not Found.");
            }

            if (string.Compare(input.HeadWorksType, "Barrage", true) == 0)
            {
                if (
                    input.BarrageTotalLength >= 0 &&
                    input.NoOfBaysOrGates >= 0 &&
                    input.LengthOfEachBayOpening >= 0 &&
                    input.CrestElevation >= 0 &&

                    input.NoOfUndersluice >= 0 &&
                    input.NoOfUndersluiceBaysOrGates >= 0 &&
                    input.UndersluiceLengthOfEachBayOpening >= 0 &&
                    input.UndersluiceCrestElevation >= 0 &&

                    input.BarrageNoOfHeadRegulators >= 0 &&
                    input.BarrageWidthHeadRegulators >= 0 &&
                    input.BarrageNoOfHeadRegulatorsBays >= 0 &&
                    input.BarrageWidthOfEachBayOpening >= 0 &&
                    input.BarrageCrestElevation >= 0)
                {
                }
                else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type Barrage.");
                }
                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;

                input.HeadWorksTypeOther = null;
            }
            else if (string.Compare(input.HeadWorksType, "Wier", true) == 0)
            {
                if (
                    input.WeirTotalLength >= 0 &&
                    input.WeirCrestElevation >= 0 &&
                    input.WeirNoOfUndersluice >= 0 &&
                    input.WeirNoOfUndersluiceBaysOrGates >= 0 &&
                    input.WeirUndersluiceLengthOfEachBayOpening >= 0 &&
                    input.WeirUndersluiceCrestElevation >= 0 &&

                    input.WeirNoOfHeadRegulators >= 0 &&
                    input.WeirWidthHeadRegulators >= 0 &&
                    input.WeirNoOfHeadRegulatorsBays >= 0 &&
                    input.WeirWidthOfEachBayOpening >= 0 &&
                    input.WeirHeadRegulatorsCrestElevation >= 0
                    )
                { }else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type Wier.");
                }

                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;

                input.HeadWorksTypeOther = null;
            }
            else if (string.Compare(input.HeadWorksType, "BankIntake", true) == 0)
            {
                if (
                   input.BankIntakeIsGated.HasValue &&
                   input.StillLevelLength >= 0 &&
                   input.SizeOfOrificeHeight >= 0 &&
                   input.SizeOfOrificeWidth >= 0)
                { }else
                {
                    throw new UserFriendlyException("Invalid Data for HeadWork Type BankIntake.");
                }
                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.HeadWorksTypeOther = null;
            }
            else
            {
                if (string.IsNullOrEmpty(input.HeadWorksTypeOther))
                {
                    throw new UserFriendlyException("Please Specify Details for HeadWork Type Others.");
                }
                input.BarrageTotalLength = null;
                input.NoOfBaysOrGates = null;
                input.LengthOfEachBayOpening = null;
                input.CrestElevation = null;

                input.NoOfUndersluice = null;
                input.NoOfUndersluiceBaysOrGates = null;
                input.UndersluiceLengthOfEachBayOpening = null;
                input.UndersluiceCrestElevation = null;

                input.BarrageNoOfHeadRegulators = null;
                input.BarrageWidthHeadRegulators = null;
                input.BarrageNoOfHeadRegulatorsBays = null;
                input.BarrageWidthOfEachBayOpening = null;
                input.BarrageCrestElevation = null;

                input.WeirTotalLength = null;
                input.WeirCrestElevation = null;

                input.WeirNoOfUndersluice = null;
                input.WeirNoOfUndersluiceBaysOrGates = null;
                input.WeirUndersluiceLengthOfEachBayOpening = null;
                input.WeirUndersluiceCrestElevation = null;

                input.WeirNoOfHeadRegulators = null;
                input.WeirWidthHeadRegulators = null;
                input.WeirNoOfHeadRegulatorsBays = null;
                input.WeirWidthOfEachBayOpening = null;
                input.WeirHeadRegulatorsCrestElevation = null;

                input.BankIntakeIsGated = null;
                input.StillLevelLength = null;
                input.SizeOfOrificeHeight = null;
                input.SizeOfOrificeWidth = null;
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
