using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.Database.Repositories;
using Its.Ads.Api.Utils;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public class DeviceService : BaseService, IDeviceService
    {
        private readonly IDeviceRepository? repository = null;

        public DeviceService(IDeviceRepository repo) : base()
        {
            repository = repo;
        }

        public MDevice GetDeviceById(string orgId, string deviceId)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetDeviceById(deviceId);

            return result.Result;
        }

        public MVDevice? AddDevice(string orgId, MDevice device)
        {
            repository!.SetCustomOrgId(orgId);

            var r = new MVDevice();

            var result = repository!.AddDevice(device);

            r.Status = "OK";
            r.Description = "Success";
            r.Device = result;

            return r;
        }

        public MVDevice? DeleteDeviceById(string orgId, string deviceId)
        {
            var r = new MVDevice()
            {
                Status = "OK",
                Description = "Success"
            };

            if (!ServiceUtils.IsGuidValid(deviceId))
            {
                r.Status = "UUID_INVALID";
                r.Description = $"Device ID [{deviceId}] format is invalid";

                return r;
            }

            repository!.SetCustomOrgId(orgId);
            var m = repository!.DeleteDeviceById(deviceId);

            r.Device = m;
            if (m == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Device ID [{deviceId}] not found for the organization [{orgId}]";
            }

            return r;
        }

        public IEnumerable<MDevice> GetDevices(string orgId, VMDevice param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetDevices(param);

            return result;
        }

        public int GetDeviceCount(string orgId, VMDevice param)
        {
            repository!.SetCustomOrgId(orgId);
            var result = repository!.GetDeviceCount(param);

            return result;
        }

        public MVDevice? UpdateDeviceById(string orgId, string deviceId, MDevice device)
        {
            var r = new MVDevice()
            {
                Status = "OK",
                Description = "Success"
            };

            repository!.SetCustomOrgId(orgId);
            var result = repository!.UpdateDeviceById(deviceId, device);

            if (result == null)
            {
                r.Status = "NOTFOUND";
                r.Description = $"Device ID [{deviceId}] not found for the organization [{orgId}]";

                return r;
            }

            r.Device = result;
            return r;
        }
    }
}
