﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stripe
{
    public class StripeChargeService : StripeService
    {
        public StripeChargeService(string apiKey = null) : base(apiKey) { }

        public bool ExpandBalanceTransaction { get; set; }
        public bool ExpandCustomer { get; set; }
        public bool ExpandInvoice { get; set; }

        public virtual StripeCharge Create(StripeChargeCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            return CreateAsync(createOptions, requestOptions).Result;
        }

        public virtual async Task<StripeCharge> CreateAsync(StripeChargeCreateOptions createOptions, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = this.ApplyAllParameters(createOptions, Urls.Charges, false);

            var response = await Requestor.PostStringAsync(url, requestOptions);

            return Mapper<StripeCharge>.MapFromJson(response);
        }

        public virtual StripeCharge Get(string chargeId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Charges, chargeId);
            url = this.ApplyAllParameters(null, url, false);

            var response = Requestor.GetString(url, requestOptions);

            return Mapper<StripeCharge>.MapFromJson(response);
        }

        public virtual async Task<StripeCharge> GetAsync(string chargeId, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}", Urls.Charges, chargeId);
            url = this.ApplyAllParameters(null, url, false);

            var response = await Requestor.GetStringAsync(url, requestOptions);

            return Mapper<StripeCharge>.MapFromJson(response);
        }

        public virtual IEnumerable<StripeCharge> List(StripeChargeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            return ListAsync(listOptions, requestOptions).Result;
        }

        public virtual async Task<IEnumerable<StripeCharge>> ListAsync(StripeChargeListOptions listOptions = null, StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = Urls.Charges;
            url = this.ApplyAllParameters(listOptions, url, true);

            var response = await Requestor.GetStringAsync(url, requestOptions);

            return Mapper<StripeCharge>.MapCollectionFromJson(response);
        }

        public virtual StripeCharge Capture(string chargeId, int? captureAmount = null, int? applicationFee = null, StripeRequestOptions requestOptions = null)
        {
            return CaptureAsync(chargeId, captureAmount, applicationFee, requestOptions).Result;
        }

        public virtual async Task<StripeCharge> CaptureAsync(string chargeId, int? captureAmount = null, int? applicationFee = null,
            StripeRequestOptions requestOptions = null)
        {
            requestOptions = SetupRequestOptions(requestOptions);

            var url = string.Format("{0}/{1}/capture", Urls.Charges, chargeId);
            url = this.ApplyAllParameters(null, url, false);

            if (captureAmount.HasValue)
                url = ParameterBuilder.ApplyParameterToUrl(url, "amount", captureAmount.Value.ToString());
            if (applicationFee.HasValue)
                url = ParameterBuilder.ApplyParameterToUrl(url, "application_fee", applicationFee.Value.ToString());

            var response = await Requestor.PostStringAsync(url, requestOptions);

            return Mapper<StripeCharge>.MapFromJson(response);
        }
    }
}
