ML.NET�ǿ�Դ�ģ���
https://github.com/dotnet/machinelearning


.NET Core��ת����ѧϰ
https://www.cnblogs.com/BeanHsiang/p/9010267.html

��װ.NET SDK 
Ϊ�˴���һ��.NETӦ�ã��������� .NET SDK��  

����Ӧ��
ʹ�����������ʼ����Ŀ������һ������̨Ӧ�ó���Ŀ��ΪmyApp��
��װML.NET��
ʹ���������װMicrosoft.ML����
�ű����£�
dotnet new console -o myApp
cd myApp
dotnet add package Microsoft.ML

�������أ�
https://archive.ics.uci.edu/ml/machine-learning-databases/iris/iris.data

���ʽ�����Iris Setosa(ɽ�β)��Iris Versicolour(��ɫ�β),�Լ�Iris Virginica(ά�������β)��

--**��ϲ�� �Ǹ����netcoreapp2.0������csproj�����***--
<AppendTargetFrameworkToOutputPath>false</AppendTargetFrameworkToOutputPath>