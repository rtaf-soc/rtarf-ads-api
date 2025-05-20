using Its.Ads.Api.Models;
using Its.Ads.Api.ViewsModels;
using LinqKit;
using Microsoft.EntityFrameworkCore;

namespace Its.Ads.Api.Database.Repositories
{
    public class DeviceRepository : BaseRepository, IDeviceRepository
    {
        public DeviceRepository(IDataContext ctx)
        {
            context = ctx;
        }

        public Task<MDevice> GetDeviceById(string deviceId)
        {
            Guid id = Guid.Parse(deviceId);
            var result = context!.Devices!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefaultAsync();

            return result!;
        }

        public MDevice AddDevice(MDevice device)
        {
            device.Id = Guid.NewGuid();
            device.CreatedDate = DateTime.UtcNow;
            device.OrgId = orgId;

            context!.Devices!.Add(device);
            context.SaveChanges();

            return device;
        }

        public MDevice? DeleteDeviceById(string deviceId)
        {
            Guid id = Guid.Parse(deviceId);

            var r = context!.Devices!.Where(x => x.OrgId!.Equals(orgId) && x.Id.Equals(id)).FirstOrDefault();
            if (r != null)
            {
                context!.Devices!.Remove(r);
                context.SaveChanges();
            }

            return r;
        }

        public IEnumerable<MDevice> GetDevices(VMDevice param)
        {
            var limit = 0;
            var offset = 0;

            //Param will never be null
            if (param.Offset > 0)
            {
                //Convert to zero base
                offset = param.Offset-1;
            }

            if (param.Limit > 0)
            {
                limit = param.Limit;
            }

            var predicate = DevicePredicate(param!);
            var arr = context!.Devices!.Where(predicate)
                .OrderByDescending(e => e.CreatedDate)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return arr;
        }

        private ExpressionStarter<MDevice> DevicePredicate(VMDevice param)
        {
            var pd = PredicateBuilder.New<MDevice>();

            pd = pd.And(p => p.OrgId!.Equals(orgId));

            if ((param.FullTextSearch != "") && (param.FullTextSearch != null))
            {
                var fullTextPd = PredicateBuilder.New<MDevice>();
                fullTextPd = fullTextPd.Or(p => p.Name!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Description!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Model!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Brand!.Contains(param.FullTextSearch));
                fullTextPd = fullTextPd.Or(p => p.Tags!.Contains(param.FullTextSearch)); //Use this to store CVEs

                pd = pd.And(fullTextPd);
            }

            return pd;
        }

        public int GetDeviceCount(VMDevice param)
        {
            var predicate = DevicePredicate(param);
            var cnt = context!.Devices!.Where(predicate).Count();

            return cnt;
        }

        public MDevice? UpdateDeviceById(string deviceId, MDevice device)
        {
            Guid id = Guid.Parse(deviceId);
            var result = context!.Devices!.Where(x => x.OrgId!.Equals(orgId) && x.Id!.Equals(id)).FirstOrDefault();

            if (result != null)
            {
                result.Description = device.Description;
                result.IpAddress = device.IpAddress;
                result.Tags = device.Tags;
                result.Brand = device.Brand;
                result.Model = device.Model;

                context!.SaveChanges();
            }

            return result!;
        }
    }
}