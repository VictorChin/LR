Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports VBMVVMCalculator

<TestClass()> Public Class CalculatorModelTest

    <TestMethod()> Public Sub Calculator_Sum_Should_Populate_Result()
        'Arrange
        Dim _Class_Under_Test As New CalculatorModel
        _Class_Under_Test.Input1 = 1
        _Class_Under_Test.Input2 = 1
        'Act
        _Class_Under_Test.Sum()
        'Assert
        Assert.IsNotNull(_Class_Under_Test.result)

    End Sub
    <TestMethod()> Public Sub Calculator_Should_Have_Initial_Input1_Of_Null()
        'Arrange
        Dim _Class_Under_Test As CalculatorModel
        'Act 
        _Class_Under_Test = New CalculatorModel()
        'Assert
        Assert.IsNull(_Class_Under_Test.Input1)
    End Sub

    <TestMethod()> Public Sub Calculator_Should_Have_Initial_Input2_Of_Null()
        'Arrange
        Dim _Class_Under_Test As CalculatorModel
        'Act 
        _Class_Under_Test = New CalculatorModel()
        'Assert
        Assert.IsNull(_Class_Under_Test.Input2)
    End Sub

    <TestMethod()> Public Sub Calculator_Sum_Should_Add_Input1_And_Input2()
        'Arrange
        Dim _Class_Under_Test As New CalculatorModel
        _Class_Under_Test.Input1 = 10
        _Class_Under_Test.Input2 = 10
        'Act 
        _Class_Under_Test.Sum()
        'Assert
        Assert.AreEqual(_Class_Under_Test.result, 20)
    End Sub

End Class