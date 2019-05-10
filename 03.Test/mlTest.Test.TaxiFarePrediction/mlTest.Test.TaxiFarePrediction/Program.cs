using System;
using System.IO;
using Microsoft.Data.DataView;
using Microsoft.ML;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;

namespace mlTest.Test.TaxiFarePrediction
{
    class Program
    {
        static readonly string _trainDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-train.csv");
        static readonly string _testDataPath = Path.Combine(Environment.CurrentDirectory, "Data", "taxi-fare-test.csv");
        static readonly string _modelPath = Path.Combine(Environment.CurrentDirectory, "Data", "Model.zip");

        static void Main(string[] args)
        {
            MLContext mlContext = new MLContext(seed: 0);

            //  Create, Training, Evaluate, Save Model
            BuildTrainEvaluateAndSaveModel(mlContext);




            var model = Train(mlContext, _trainDataPath);
        }

        private static ITransformer BuildTrainEvaluateAndSaveModel(MLContext mlContext)
        {
            //  데이타 로딩 설정

            IDataView baseTrainingDataView = mlContext.Data.LoadFromTextFile<TaxiTrip>(_trainDataPath, hasHeader: true, separatorChar: ',');
            IDataView testDataView = mlContext.Data.LoadFromTextFile<TaxiTrip>(_testDataPath, hasHeader: true, separatorChar: ',');

            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mLContext"></param>
        /// <param name="trainDataPath"></param>
        /// <returns></returns>
        private static ITransformer Train(MLContext mLContext, string trainDataPath)
        {
            //  데이타 로딩 설정
            IDataView dataView = mLContext.Data.LoadFromTextFile<TaxiTrip>(trainDataPath, hasHeader: true, separatorChar: ',');

            var pipeline = mLContext.Transforms
                                                //  설명을 남길것! Why?
                                                .CopyColumns(outputColumnName: "Label", inputColumnName: "FareAmount")

                                                //  숫자로 형변환 -> VendorId, RateCode, PaymentType
                                                .Append(mLContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "VendorIdEncoded", inputColumnName: "VendorId"))
                                                .Append(mLContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "RateCodeEncoded", inputColumnName: "RateCode"))
                                                .Append(mLContext.Transforms.Categorical.OneHotEncoding(outputColumnName: "PaymentTypeEncoded", inputColumnName: "PaymentType"))

                                                //  작업할 데이타 최종정리
                                                .Append
                                                (
                                                    mLContext.Transforms.Concatenate
                                                    (
                                                        "Features"
                                                        , "VendorIdEncoded"
                                                        , "RateCodeEncoded"
                                                        , "PassengerCount"
                                                        , "Triptime"
                                                        , "TripDistance"
                                                        , "PaymentTypeEncoded"
                                                    )
                                                )

                                                //  학습알고리즘 선택 - 
                                                .Append(mLContext.Regression.Trainers.FastTree());


            //  알고리즘에 따른 모델 학습 -> return value : 예측에 사용될 모델
            var model = pipeline.Fit(dataView);

            SaveModelAsFile(mLContext, dataView.Schema, model);

            return model;
        }

        /// <summary>
        /// Model -> Zip
        /// </summary>
        /// <param name="mLContext"></param>
        /// <param name="schema"></param>
        /// <param name="model"></param>
        private static void SaveModelAsFile(MLContext mLContext, DataViewSchema schema, ITransformer model)
        {
            //  mLContext.Model.Save(model, schema, _modelPath);

            throw new NotImplementedException();
        }
    }
}
