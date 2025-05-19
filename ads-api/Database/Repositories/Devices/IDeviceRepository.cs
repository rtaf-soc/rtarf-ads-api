using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;

namespace Its.Ads.Api.Database.Repositories
{
    public interface IDeviceRepository
    {
        public void SetCustomOrgId(string customOrgId);
        public Task<MDevice> GetDeviceById(string deviceId);
        public MDevice AddDevice(MDevice device);
        public MDevice? DeleteDeviceById(string deviceId);
        public IEnumerable<MDevice> GetDevices(VMDevice param);
        public int GetDeviceCount(VMDevice param);
        public MDevice? UpdateDeviceById(string deviceId, MDevice device);
    }
}
