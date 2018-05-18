ML.NET是开源的！！
https://github.com/dotnet/machinelearning


.NET Core玩转机器学习
https://www.cnblogs.com/BeanHsiang/p/9010267.html

安装.NET SDK 
为了创建一个.NET应用，首先下载 .NET SDK。  

创建应用
使用如下命令初始化项目，创建一个控制台应用程序，目标为myApp：
安装ML.NET包
使用如下命令安装Microsoft.ML包：
脚本如下：
dotnet new console -o myApp
cd myApp
dotnet add package Microsoft.ML

数据下载：
https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data

名词解析：Iris Setosa(山鸢尾)、Iris Versicolour(杂色鸢尾),以及Iris Virginica(维吉尼亚鸢尾)。

--**不喜欢 那个输出netcoreapp2.0的请在csproj中添加***--
<AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>