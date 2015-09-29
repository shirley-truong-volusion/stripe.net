using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stripe
{
    public class StripeRefundService : StripeService
    {
        public StripeRefundService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }

        public virtual StripeRefund Create(string chargeId, StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(chargeId, createOptions, requestOptions).Result;
        }

        public virtual async Task<StripeRefund> CreateAsync(string chargeId, StripeRefundCreateOptions createOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/refunds", Urls.Charges, chargeId);
            url = this.ApplyAllParameters(createOptions, url, false);

            var response = await Requestor.PostStringAsync(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual StripeRefund Get(string chargeId, string refundId, StripeRequestOptions requestOptions = null)
        {
            return GetAsync(chargeId, refundId, requestOptions).Result;
        }

        public virtual async Task<StripeRefund> GetAsync(string chargeId, string refundId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/refunds/{2}", Urls.Charges, chargeId, refundId);
            url = this.ApplyAllParameters(null, url, false);

            var response = await Requestor.GetStringAsync(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual StripeRefund Update(string chargeId, string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            return UpdateAsync(chargeId, refundId, updateOptions, requestOptions).Result;
        }

        public virtual async Task<StripeRefund> UpdateAsync(string chargeId, string refundId, StripeRefundUpdateOptions updateOptions, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/refunds/{2}", Urls.Charges, chargeId, refundId);
            url = this.ApplyAllParameters(updateOptions, url, false);

            var response = await Requestor.PostStringAsync(url, requestOptions);

            return Mapper<StripeRefund>.MapFromJson(response);
        }

        public virtual IEnumerable<StripeRefund> List(string chargeId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(chargeId, listOptions, requestOptions).Result;
        }

        public virtual async Task<IEnumerable<StripeRefund>> ListAsync(string chargeId, StripeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/refunds", Urls.Charges, chargeId);
            url = this.ApplyAllParameters(listOptions, url, true);

            var response = await Requestor.GetStringAsync(url, requestOptions);

            return Mapper<StripeRefund>.MapCollectionFromJson(response);
        }
    }
}
