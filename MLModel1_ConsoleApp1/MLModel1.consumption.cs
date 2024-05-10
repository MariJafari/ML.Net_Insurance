﻿// This file was auto-generated by ML.NET Model Builder.
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace MLModel1_ConsoleApp1
{
    public partial class MLModel1
    {
        /// <summary>
        /// model input class for MLModel1.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [LoadColumn(0)]
            [ColumnName(@"age")]
            public float Age { get; set; }

            [LoadColumn(1)]
            [ColumnName(@"sex")]
            public string Sex { get; set; }

            [LoadColumn(2)]
            [ColumnName(@"bmi")]
            public float Bmi { get; set; }

            [LoadColumn(3)]
            [ColumnName(@"children")]
            public float Children { get; set; }

            [LoadColumn(4)]
            [ColumnName(@"smoker")]
            public bool Smoker { get; set; }

            [LoadColumn(5)]
            [ColumnName(@"region")]
            public string Region { get; set; }

            [LoadColumn(6)]
            [ColumnName(@"charges")]
            public float Charges { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModel1.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"age")]
            public float Age { get; set; }

            [ColumnName(@"sex")]
            public float[] Sex { get; set; }

            [ColumnName(@"bmi")]
            public float Bmi { get; set; }

            [ColumnName(@"children")]
            public float Children { get; set; }

            [ColumnName(@"smoker")]
            public float[] Smoker { get; set; }

            [ColumnName(@"region")]
            public float[] Region { get; set; }

            [ColumnName(@"charges")]
            public float Charges { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModel1.mlnet");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);


        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

    }
}
