using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.ML.Data;

namespace mlTest.Test.TaxiFarePrediction
{
    public class TaxiTrip
    {
        /*
         * vendor_id,rate_code,passenger_count,trip_time_in_secs,trip_distance,payment_type,fare_amount
        */
        [LoadColumn(0)]
        public string VendorId;
        [LoadColumn(1)]
        public string RateCode;
        [LoadColumn(2)]
        public float PassengerCount;
        [LoadColumn(3)]
        public float Triptime;
        [LoadColumn(4)]
        public float TripDistance;
        [LoadColumn(5)]
        public string PaymentType;
        [LoadColumn(6)]
        public float FareAmount;
    }

    public class TaxiTripFarePrediction
    {
        [ColumnName("Score")]
        public float FareAmount;
    }
}
