using System.Collections.Generic;
using Newtonsoft.Json;
using System;

namespace Stripe
{
    public class StripeChargeCreateOptions
    {
        [JsonProperty("amount")]
        public int? Amount { get; set; }

        [JsonProperty("currency")]
        public string Currency { get; set; }

        [JsonProperty("customer")]
        public string CustomerId { get; set; }

        [JsonProperty("source")]
        public StripeSourceOptions Source { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("metadata")]
        public Dictionary<string, string> Metadata { get; set; }

        [JsonProperty("capture")]
        public bool? Capture { get; set; }

        [JsonProperty("statement_descriptor")]
        public string StatementDescriptor { get; set; }

        [JsonProperty("receipt_email")]
        public string ReceiptEmail { get; set; }

        [JsonProperty("destination")]
        public string Destination { get; set; }

        [JsonProperty("application_fee")]
        public int? ApplicationFee { get; set; }

        // shipping

        /// <summary>
        /// The cardholder IP.
        /// </summary>
        [JsonProperty("ip")]
        public string Ip { get; set; }

        /// <summary>
        /// The user agent for the cardholder's browser.
        /// </summary>
        [JsonProperty("user_agent")]
        public string UserAgent { get; set; }

        /// <summary>
        /// The URL for the page containing the payment form.
        /// </summary>
        [JsonProperty("referrer")]
        public string Referrer { get; set; }

        /// <summary>
        /// A unique identifier for a cardholder.
        /// </summary>
        [JsonProperty("external_id")]
        public string ExternalId { get; set; }

        /// <summary>
        /// An identifier for the calling library, for example "Stripe.Net".
        /// </summary>
        [JsonProperty("payment_user_agent")]
        public string PaymentUserAgent { get; set; }
    }
}