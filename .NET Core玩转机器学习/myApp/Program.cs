using System;
using Microsoft.ML;
using Microsoft.ML.Runtime.Api;
using Microsoft.ML.Trainers;
using Microsoft.ML.Transforms;

namespace myApp
{
    class Program
    {
        // STEP 1: 定义数据结构。从文本数据块中的鸢尾花数据用来训练模型

        // IrisData is used to provide training data, and as 
        // input for prediction operations
        // - First 4 properties are inputs/features used to predict the label
        // - Label is what you are predicting, and is only set when training
        /*
         每一行表示不同鸢尾花的样本，数值的部分从左到右依次是萼片长度、萼片宽度、花瓣长度、花瓣宽度，最后是鸢尾花的类型。
        */

        /// <summary>
        /// 鸢尾花建模
        /// </summary>
        public class IrisData
        {
            /// <summary>
            /// 萼片长
            /// </summary>
            [Column("0")]
            public float SepalLength;
            /// <summary>
            /// 萼片宽
            /// </summary>
            [Column("1")]
            public float SepalWidth;

            /// <summary>
            /// 花瓣长
            /// </summary>
            [Column("2")]
            public float PetalLength;
            /// <summary>
            /// 花瓣宽
            /// </summary>
            [Column("3")]
            public float PetalWidth;

            /// <summary>
            /// 品种名称
            /// </summary>
            [Column("4")]
            [ColumnName("Label")]
            public string Label;
        }

        // IrisPrediction is the result returned from prediction operations
        /// <summary>
        /// 结果模型
        /// </summary>
        public class IrisPrediction
        {
            [ColumnName("PredictedLabel")]
            public string PredictedLabels;
        }

        static void Main(string[] args)
        {
            // STEP 2: Create a pipeline and load your data
            var pipeline = new LearningPipeline();

            // If working in Visual Studio, make sure the 'Copy to Output Directory' 
            // property of iris-data.txt is set to 'Copy always'
            //加载文本数据块
            string dataPath = "iris-data.txt";
            pipeline.Add(new TextLoader<IrisData>(dataPath, separator: ","));

            // STEP 3: Transform your data
            // Assign numeric values to text in the "Label" column, because only
            // numbers can be processed during model training
            //初始化一个数据字典的索引标记
            pipeline.Add(new Dictionarizer("Label"));

            // Puts all features into a vector
            //特征矢量
            pipeline.Add(
                new ColumnConcatenator("Features", 
                new string[] { "SepalLength", "SepalWidth", "PetalLength", "PetalWidth" })
                );

            // STEP 4: Add learner
            // Add a learning algorithm to the pipeline. 
            // This is a classification scenario (What type of iris is this?)
            //创建学习算法--随机双坐标上升
            pipeline.Add(new StochasticDualCoordinateAscentClassifier());

            // Convert the Label back into original text (after converting to number in step 3)
            //结果输出转换
            pipeline.Add(new PredictedLabelColumnOriginalValueConverter() { PredictedLabelColumn = "PredictedLabel" });

            // STEP 5: Train your model based on the data set
            //开始训练模型
            var model = pipeline.Train<IrisData, IrisPrediction>();

            // STEP 6: Use your model to make a prediction
            // You can change these numbers to test different predictions
            //对自定义的数据进行识别
            var prediction = model.Predict(new IrisData()
            {
                SepalLength = 3.3f,
                SepalWidth = 1.6f,
                PetalLength = 0.2f,
                PetalWidth = 5.1f,
            });

            Console.WriteLine($"Predicted flower type is: {prediction.PredictedLabels}");
        }
    }
}