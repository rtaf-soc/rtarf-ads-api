using Its.Ads.Api.Models;
using Its.Ads.Api.ModelsViews;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Services
{
    public interface IDeviceService
    {
        public MDevice GetDeviceById(string orgId, string deviceId);
        public MVDevice? AddDevice(string orgId, MDevice device);
        public MVDevice? DeleteDeviceById(string orgId, string deviceId);
        public IEnumerable<MDevice> GetDevices(string orgId, VMDevice param);
        public int GetDeviceCount(string orgId, VMDevice param);
        public MVDevice? UpdateDeviceById(string orgId, string deviceId, MDevice device);
    }
}
