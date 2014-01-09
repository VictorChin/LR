Imports System.Text
Imports Microsoft.VisualStudio.TestTools.UnitTesting
Imports Ninject
Imports VBMVVMCalculator
<TestClass()> Public Class NoteCalculatorTest
    Private kernel As New StandardKernel()
    <TestMethod()> Public Sub NoteCalculator_Calculate_should_populate_result()
        'arrange
        kernel.Bind(Of ICalculatorModel).To(Of NoteCalculator)()
        kernel.Bind(Of INoteProductionGetter).To(Of NoteProductionGetter)()

        Dim object_under_test = kernel.Get(Of NoteCalculator)()
        'act
        object_under_test.Calculate()
        'assert
        Assert.IsNotNull(object_under_test.result)
    End Sub


    <TestMethod()> Public Sub NoteCalculator_FY2009_Produced_716800000_20Bills()
        'arrange
        kernel.Bind(Of ICalculatorModel).To(Of NoteCalculator)()
        kernel.Bind(Of INoteProductionGetter).To(Of NoteProductionGetter)()
        Dim object_under_test = kernel.Get(Of NoteCalculator)()
        'act
        object_under_test.Input1 = 2009
        object_under_test.Input2 = 20
        Dim expected = 716800000
        object_under_test.Calculate()
        'assert
        Assert.AreEqual(object_under_test.result, expected)
    End Sub

End Class
